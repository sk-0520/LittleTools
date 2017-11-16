namespace MarkdownTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        enum Page
        {
            Markdown,
            Grid,
        }

        enum MarkdownFormat
        {
            Bitbucket,
        }

        enum CellAlign
        {
            None,
            Left,
            Center,
            Right,
        }

        public Form1()
        {
            InitializeComponent();

            var baseFont = SystemFonts.MessageBoxFont;
            var family = FontFamily.Families.FirstOrDefault(f => f.Name == "Meiryo UI");
            if(family != null) {
                baseFont = new Font(family, baseFont.SizeInPoints, baseFont.Style, GraphicsUnit.Point);
            }
            Font = baseFont;
        }

        #region function

        static DataGridViewContentAlignment ToDataGridViewContentAlignment(CellAlign ca)
        {
            switch(ca) {
                case CellAlign.Left:
                    return DataGridViewContentAlignment.MiddleLeft;
                case CellAlign.Center:
                    return DataGridViewContentAlignment.MiddleCenter;
                case CellAlign.Right:
                    return DataGridViewContentAlignment.MiddleRight;
                default:
                    throw new NotImplementedException();
            }
        }

        static CellAlign ToCellAlign(DataGridViewContentAlignment align)
        {
            switch(align) {
                case DataGridViewContentAlignment.MiddleCenter:
                    return CellAlign.Center;
                case DataGridViewContentAlignment.MiddleRight:
                    return CellAlign.Right;
                default:
                    return CellAlign.Left;
            }
        }

        static IEnumerable<string> SplitLines(string lines)
        {
            using(var stream = new StringReader(lines)) {
                string line = null;
                while((line = stream.ReadLine()) != null) {
                    yield return line;
                }
            }
        }

        static IEnumerable<string> SplitCells(string line)
        {
            if(string.IsNullOrWhiteSpace(line)) {
                throw new Exception(line);
            }

            return new string(
                line
                    .Trim()
                    .SkipWhile(c => c == '|')
                    .Reverse()
                    .SkipWhile(c => c == '|')
                    .Reverse()
                    .ToArray()
                )
                .Split('|')
                .Select(s => s.Trim())
            ;
        }

        static CellAlign GetCellAlign(string separator)
        {
            if(string.IsNullOrWhiteSpace(separator)) {
                return CellAlign.Left;
            }
            var s = separator.Trim();
            var l = s.FirstOrDefault();
            var r = s.LastOrDefault();

            if(l == ':' && r == ':') {
                return CellAlign.Center;
            }
            if(r == ':') {
                return CellAlign.Right;
            }

            return CellAlign.Left;
        }

        static int GetTextWidth(string s)
        {
            // いろいろ調べてみたがあまりにもだるい
            return Encoding.Default.GetByteCount(s);
        }

        static string SeparatorFromCellAlign(CellAlign ca, int width)
        {
            switch(ca) {
                case CellAlign.Left:
                    return ":" + new string('-', width - 1);
                case CellAlign.Right:
                    return new string('-', width - 1) + ":";
                case CellAlign.Center:
                    return ":" + new string('-', width - 2) + ":";
                default:
                    throw new NotImplementedException();
            }
        }

        static string Centering(string s, int width)
        {
            var spaces = width - GetTextWidth(s);
            var padding = spaces / 2;
            var left = new string(' ', padding);
            var right = new string(' ', padding + spaces % 2);
            return left + s + right;
        }

        static string ToRowText(IEnumerable<string> cell, IEnumerable<int> width, IEnumerable<CellAlign> align)
        {
            var map = new Dictionary<CellAlign, Func<string, int, string>> {
                { CellAlign.Left, (s, w) => s + new string(' ', w - GetTextWidth(s)) },
                { CellAlign.Right, (s, w) => new string(' ', w - GetTextWidth(s)) + s },
                { CellAlign.Center, Centering },
            };
            var row = cell
                .Select((v, i) => new { Text = v, Index = i })
                .Zip(width, (v, w) => new { Value = v, Width = w })
                .Select(v => map[align.ElementAt(v.Value.Index)](v.Value.Text, v.Width))
            ;
            return string.Format("| {0} |", string.Join(" | ", row));
        }

        static string ToSeparatorText(IEnumerable<CellAlign> cell, IEnumerable<int> width)
        {
            var row = cell
                .Zip(width, (s, w) => new { Text = s, Width = w + 2 })
                .Select(v => SeparatorFromCellAlign(v.Text, v.Width))
            ;
            return string.Format("|{0}|", string.Join("|", row));
        }

        void AddColumn(string text, CellAlign ca)
        {
            var col = new DataGridViewColumn();
            col.HeaderText = text;
            col.DefaultCellStyle.Alignment = ToDataGridViewContentAlignment(ca);
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            var template = new DataGridViewTextBoxCell();
            template.Style.Alignment = ToDataGridViewContentAlignment(ca);
            col.CellTemplate = template;

            this.gridGrid.Columns.Add(col);
        }

        void AddDefualtColumn()
        {
            var headerText = Properties.Resources.Text_DefaultHeader;
            if(this.gridGrid.ColumnCount >= 1) {
                headerText = string.Format("{0}:{1}", headerText, this.gridGrid.ColumnCount);
            }
            AddColumn(headerText, CellAlign.Left);
        }

        void ToGrid(string markdown, MarkdownFormat foramt)
        {
            this.gridGrid.Rows.Clear();
            this.gridGrid.Columns.Clear();

            var lines = SplitLines(markdown).Where(s => !string.IsNullOrWhiteSpace(s));

            if(lines.Count() < 2) {
                // 空データと判断。
                AddDefualtColumn();
            } else {
                var header = SplitCells(lines.ElementAt(0));
                var cellAlign = SplitCells(lines.ElementAt(1)).Select(GetCellAlign);
                // データをすべて回す
                var data = lines
                    .Skip(2)
                    .Select(SplitCells)
                ;
                // 列数
                //var columnCount = new[] { header.Count(), cellAlign.Count(), data.Select(d => d.Count()).Max(), }.Max();
                var columnCount = new[] { header.Count(), cellAlign.Count(), }.Max();

                // グリッドへ当てていく
                // ヘッダー
                var headerGroups = header.Zip(cellAlign, (s, ca) => new {
                    Text = s,
                    CellAlign = ca
                });
                foreach(var headerGroup in headerGroups) {
                    AddColumn(headerGroup.Text, headerGroup.CellAlign);
                }
                // データ
                foreach(var cells in data) {
                    var row = new DataGridViewRow();
                    row.CreateCells(this.gridGrid);
                    foreach(var cell in cells.Take(columnCount).Select((value, index) => new { Value = value, Index = index })) {
                        row.Cells[cell.Index].Value = cell.Value;
                    }
                    this.gridGrid.Rows.Add(row);
                }
            }
            this.gridGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        string ToMarkdown(MarkdownFormat foramt)
        {
            var columns = this.gridGrid.Columns.Cast<DataGridViewColumn>().OrderBy(c => c.DisplayIndex).ToArray();
            var header = columns.Select(c => c.HeaderText);
            var separator = columns.Select(c => ToCellAlign(c.DefaultCellStyle.Alignment));
            var data = this.gridGrid.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => r.Cells
                    .Cast<DataGridViewCell>()
                    .OrderBy(c => this.gridGrid.Columns[c.ColumnIndex].DisplayIndex)
                    .Select(c => c.Value as string ?? string.Empty)
                )
            ;

            var minWidthList = new List<int>(header.Select(GetTextWidth));
            foreach(var r in data) {
                foreach(var c in r.Select((v, i) => new { Value = GetTextWidth(v), Index = i })) {
                    minWidthList[c.Index] = Math.Max(minWidthList[c.Index], c.Value);
                }
            }

            var result = new StringBuilder(minWidthList.Sum() * (data.Count() + 2 + "|  |".Length));
            var headerText = ToRowText(header, minWidthList, Enumerable.Repeat(CellAlign.Center, minWidthList.Count));
            var separatorText = ToSeparatorText(separator, minWidthList);
            result.AppendLine(headerText);
            result.AppendLine(separatorText);
            foreach(var r in data) {
                var dataText = ToRowText(r, minWidthList, separator);
                result.AppendLine(dataText);
            }

            return result.ToString();
        }

        void ChangePage(Page page)
        {
            if(page == Page.Markdown) {
                this.inputMarkdown.Text = ToMarkdown(MarkdownFormat.Bitbucket);
            } else if(page == Page.Grid) {
                var markdown = this.inputMarkdown.Text;
                ToGrid(markdown, MarkdownFormat.Bitbucket);
            }
        }

        void ChangeAlign(IEnumerable<DataGridViewColumn> columns, CellAlign ca)
        {
            foreach(var column in columns) {
                column.DefaultCellStyle.Alignment = column.CellTemplate.Style.Alignment = ToDataGridViewContentAlignment(ca);
                foreach(var cell in this.gridGrid.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[column.Index])) {
                    cell.Style.Alignment = ToDataGridViewContentAlignment(ca);
                }
            }
        }

        void SwapRow(DataGridViewRow src, DataGridViewRow target)
        {
            var insertIndex1 = src.Index;
            var insertIndex2 = target.Index;

            this.gridGrid.Rows.Remove(src);
            this.gridGrid.Rows.Insert(insertIndex2, src);
            this.gridGrid.Rows.Remove(target);
            this.gridGrid.Rows.Insert(insertIndex1, target);

            this.gridGrid.ClearSelection();
            src = this.gridGrid.Rows[insertIndex2];
            src.Selected = true;
            this.gridGrid.Rows[insertIndex2].Selected = true;
            this.gridGrid.CurrentCell = src.Cells[this.gridGrid.CurrentCell.ColumnIndex];
            this.gridGrid.FirstDisplayedScrollingRowIndex = src.Index;
        }

        bool SwapUpRow()
        {
            var nowRow = GetSingleRowFromSelectedCell();
            if(nowRow != null && 0 < nowRow.Index) {
                var nextRow = this.gridGrid.Rows[nowRow.Index - 1];
                SwapRow(nowRow, nextRow);

                return true;
            }

            return false;
        }

        bool SwapDownRow()
        {
            var nowRow = GetSingleRowFromSelectedCell();
            if(nowRow != null && nowRow.Index + 1 < this.gridGrid.RowCount - 1) {
                var nextRow = this.gridGrid.Rows[nowRow.Index + 1];
                SwapRow(nowRow, nextRow);

                return true;
            }

            return false;
        }

        void PasteTextToGrid(string text)
        {
            var startCell = this.gridGrid.CurrentCell;
            var startCellDisplayIndex = this.gridGrid.Columns[startCell.ColumnIndex].DisplayIndex;

            foreach(var row in SplitLines(text).Select((line, i) => new { Value = line, Index = startCell.RowIndex + i })) {
                if(row.Index >= this.gridGrid.RowCount - 1) {
                    return;
                }

                var cells = this.gridGrid.Rows[row.Index].Cells
                    .Cast<DataGridViewCell>()
                    .OrderBy(c => this.gridGrid.Columns[c.ColumnIndex].DisplayIndex)
                ;
                foreach(var col in row.Value.Split('\t').Select((s, i) => new { Value = s, Index = startCellDisplayIndex + i })) {
                    if(col.Index >= this.gridGrid.ColumnCount) {
                        break;
                    }
                    var cell = cells.ElementAt(col.Index);
                    cell.Value = col.Value;
                }
            }
        }

        void PasteClipboardToGrid()
        {
            var text = Clipboard.GetText(TextDataFormat.UnicodeText);
            if(string.IsNullOrEmpty(text)) {
                return;
            }

            PasteTextToGrid(text);
        }

        DataGridViewRow GetSingleRowFromSelectedCell()
        {
            return this.gridGrid.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.OwningRow)
                .Where(r => !r.IsNewRow)
                .Distinct()
                .FirstOrDefault()
            ;
        }

        void EditColumnName(DataGridViewColumn column)
        {
            var form = new Form() {
                Font = this.Font,
                StartPosition = FormStartPosition.CenterParent,
                ShowInTaskbar = false,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow,
                MaximizeBox = false,
                MinimizeBox = false,
                Text = Properties.Resources.Text_ColumnEditTitle,
            };

            var commandSubmit = new Button() {
                Text = Properties.Resources.Text_CommonOk,
                Anchor = AnchorStyles.Left,
            };
            commandSubmit.Click += (senderChild, eChild) => {
                form.DialogResult = System.Windows.Forms.DialogResult.OK;
            };

            var commandCancel = new Button() {
                Text = Properties.Resources.Text_CommonCancel,
                Anchor = AnchorStyles.Right,
            };

            var inputHeader = new TextBox() {
                Dock = DockStyle.Top,
                Text = column.HeaderText,
            };
            inputHeader.Validating += (senderChild, eChild) => {
                if(form.ActiveControl == inputHeader || form.ActiveControl == commandSubmit) {
                    eChild.Cancel = inputHeader.Text.Any(c => c == '|');
                }
            };

            var panel = new TableLayoutPanel();
            panel.Controls.Add(inputHeader, 0, 0);
            panel.SetColumnSpan(inputHeader, 2);
            panel.Controls.Add(commandSubmit, 0, 1);
            panel.Controls.Add(commandCancel, 1, 1);

            panel.AutoSize = true;
            panel.Size = Size.Empty;

            form.Controls.Add(panel);

            form.AcceptButton = commandSubmit;
            form.CancelButton = commandCancel;

            form.AutoSize = true;
            form.Size = Size.Empty;

            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                var s = inputHeader.Text.Trim();
                if(s != column.HeaderText) {
                    column.HeaderText = s;
                }
            }
        }

        void EditSelectedColumnName()
        {
            var column = this.gridGrid.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.OwningColumn)
                .Distinct()
                .FirstOrDefault()
            ;

            if(column != null) {
                EditColumnName(column);
            }
        }


        #endregion

        private void tabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try {
                if(e.TabPage == this.tabMain_pageGrid) {
                    ChangePage(Page.Grid);
                } else if(e.TabPage == this.tabMain_pageMarkdown) {
                    ChangePage(Page.Markdown);
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex);
                e.Cancel = true;
            }
        }

        private void toolGrid_itemColumnAdd_Click(object sender, EventArgs e)
        {
            AddDefualtColumn();
        }

        private void toolGrid_itemColumnRename_Click(object sender, EventArgs e)
        {
            EditSelectedColumnName();
        }

        private void toolGrid_itemColumnRemove_Click(object sender, EventArgs e)
        {
            foreach(var column in this.gridGrid.SelectedCells.Cast<DataGridViewCell>().Select(c => c.OwningColumn).Distinct()) {
                this.gridGrid.Columns.Remove(column);
            }
            if(this.gridGrid.ColumnCount == 0) {
                // 全部消すとさすがになぁ
                AddDefualtColumn();
            }
        }

        private void toolGrid_itemAlignLeft_Click(object sender, EventArgs e)
        {
            ChangeAlign(this.gridGrid.SelectedCells.Cast<DataGridViewCell>().Select(c => c.OwningColumn).Distinct(), CellAlign.Left);
        }

        private void toolGrid_itemAlignCenter_Click(object sender, EventArgs e)
        {
            ChangeAlign(this.gridGrid.SelectedCells.Cast<DataGridViewCell>().Select(c => c.OwningColumn).Distinct(), CellAlign.Center);
        }

        private void toolGrid_itemAlignRight_Click(object sender, EventArgs e)
        {
            ChangeAlign(this.gridGrid.SelectedCells.Cast<DataGridViewCell>().Select(c => c.OwningColumn).Distinct(), CellAlign.Right);
        }

        private void toolMarkdown_itemCopy_Click(object sender, EventArgs e)
        {
            var s = this.inputMarkdown.Text.Trim();
            if(!string.IsNullOrWhiteSpace(s)) {
                Clipboard.SetText(this.inputMarkdown.Text);
            }
        }

        private void toolMarkdown_itemPaste_Click(object sender, EventArgs e)
        {
            var s = Clipboard.GetText();
            if(!string.IsNullOrWhiteSpace(s)) {
                this.inputMarkdown.Text = s.Trim();
            }
        }

        private void toolGrid_itemRowMoveUp_Click(object sender, EventArgs e)
        {
            SwapUpRow();
        }

        private void toolGrid_itemRowMoveDown_Click(object sender, EventArgs e)
        {
            SwapDownRow();
        }

        private void gridGrid_SelectionChanged(object sender, EventArgs e)
        {
            var selectedCells = this.gridGrid.SelectedCells.Cast<DataGridViewCell>().ToArray();

            var selectedRows = selectedCells.Select(c => c.OwningRow).Distinct();
            var canRowMove = selectedRows.Count() == 1 && !selectedRows.First().IsNewRow;
            this.toolGrid_itemRowMoveUp.Enabled = canRowMove && 0 < selectedRows.First().Index;
            this.toolGrid_itemRowMoveDown.Enabled = canRowMove && selectedRows.First().Index < this.gridGrid.RowCount - 2;

            this.toolGrid_itemColumnRename.Enabled = selectedCells.Select(c => c.OwningColumn).Distinct().Count() == 1;
        }

        private void toolGrid_itemRowInsert_Click(object sender, EventArgs e)
        {
            int index = -1;
            if(this.gridGrid.SelectedRows.Count > 0) {
                index = this.gridGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r => r.Index).First().Index;
                foreach(var i in Enumerable.Repeat(0, this.gridGrid.SelectedRows.Count)) {
                    var row = new DataGridViewRow();
                    row.CreateCells(this.gridGrid);
                    this.gridGrid.Rows.Insert(index, row);
                }

            } else if(this.gridGrid.SelectedCells.Count > 0) {
                index = this.gridGrid.SelectedCells[0].RowIndex;
                var row = new DataGridViewRow();
                row.CreateCells(this.gridGrid);
                this.gridGrid.Rows.Insert(index, row);
            }

            if(index != -1) {
                this.gridGrid.ClearSelection();
                this.gridGrid.CurrentCell = this.gridGrid.Rows[index].Cells[0];
            }

        }

        private void gridGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) {
                case Keys.Delete: {
                        foreach(var cell in this.gridGrid.SelectedCells.Cast<DataGridViewCell>()) {
                            cell.Value = string.Empty;
                        }
                    }
                    break;

                case Keys.Back: {
                        var cell = this.gridGrid.SelectedCells.OfType<DataGridViewCell>().SingleOrDefault();
                        if(cell != null) {
                            cell.Value = string.Empty;
                            this.gridGrid.ClearSelection();
                            this.gridGrid.BeginEdit(false);
                        }
                    }
                    break;

                case Keys.F2:
                    if(e.Shift) {
                        EditSelectedColumnName();
                        e.Handled = true;
                    }
                    break;

                case Keys.V:
                    if(e.Control) {
                        PasteClipboardToGrid();
                    }
                    break;

                case Keys.Insert:
                    if(e.Shift) {
                        PasteClipboardToGrid();
                    }
                    break;

                case Keys.Up:
                    if(e.Alt) {
                        e.Handled = SwapUpRow();
                    }
                    break;

                case Keys.Down:
                    if(e.Alt) {
                        e.Handled = SwapDownRow();
                    }
                    break;

                case Keys.Right:
                    if(e.Alt) {
                        var cell = this.gridGrid.CurrentCell;
                        if(this.gridGrid.Columns[cell.ColumnIndex].DisplayIndex == this.gridGrid.ColumnCount - 1) {
                            AddDefualtColumn();
                        }
                    }
                    break;

                case Keys.Enter: {
                        var cell = this.gridGrid.CurrentCell;

                        var index = this.gridGrid.Columns[cell.ColumnIndex].DisplayIndex;
                        var columns = this.gridGrid.Columns
                            .Cast<DataGridViewColumn>()
                            .OrderBy(c => c.DisplayIndex)
                        ;
                        var colShift = e.Shift ? -1 : +1;
                        var column = columns.FirstOrDefault(c => c.DisplayIndex == index + colShift);

                        if(e.Shift) {
                            if(column == null) {
                                column = columns.Last();
                            }
                            if(cell.RowIndex == 0) {
                                this.gridGrid.CurrentCell = this.gridGrid.Rows[this.gridGrid.RowCount - 1].Cells[column.Index];
                            } else {
                                this.gridGrid.CurrentCell = this.gridGrid.Rows[cell.RowIndex - 1].Cells[index];
                            }
                            e.Handled = true;
                        } else {
                            if(this.gridGrid.Rows[cell.RowIndex].IsNewRow) {
                                if(column == null) {
                                    column = columns.First();
                                }
                                this.gridGrid.CurrentCell = this.gridGrid.Rows[0].Cells[column.Index];
                                e.Handled = true;
                            }
                        }
                    }
                    break;
            }
        }

        private void toolGrid_itemRowRemove_Click(object sender, EventArgs e)
        {
            var rows = this.gridGrid.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.OwningRow)
                .Where(r => !r.IsNewRow)
                .Distinct()
            ;
            foreach(var row in rows) {
                this.gridGrid.Rows.Remove(row);
            }
        }

        private void toolGrid_itemCopy_Click(object sender, EventArgs e)
        {
            var s = ToMarkdown(MarkdownFormat.Bitbucket);
            if(!string.IsNullOrWhiteSpace(s)) {
                Clipboard.SetText(s);
            }
        }

        private void toolGrid_itemPaste_Click(object sender, EventArgs e)
        {
            var s = Clipboard.GetText();
            if(!string.IsNullOrWhiteSpace(s)) {
                var markdown = s.Trim();
                ToGrid(markdown, MarkdownFormat.Bitbucket);
            }
        }
    }
}
