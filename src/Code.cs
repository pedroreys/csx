namespace csx
{
    using System.Collections.Generic;
    using System.Linq;

    using Roslyn.Compilers.CSharp;

    public class Code
    {
        private List<string> _lines = new List<string>();

        public string Text
        {
            get
            {
                var cleanLines = this._lines.Select(x => x.EndsWith("\\") ? x.Substring(0, x.Length - 1) : x);
                return string.Join("\r\n", cleanLines);
            }
        }

        public bool IsExit
        {
            get
            {
                if (this.IsEmpty()) return false;

                var lastLine = this._lines.Last();

                return lastLine == "exit()" || lastLine == "close()";
            }
        }

        public bool IsMultiline
        {
            get
            {
                if (this.IsEmpty()) return false;

                return this._lines.Last().EndsWith("\\");
            }
        }

        public void AddLine(string lineText)
        {
            this._lines.Add(lineText);
        }

        public string GetLastLine()
        {
            return _lines.Last();
        }

        public void Clear()
        {
            this._lines.Clear();
        }

        public void ClearNonLocalDeclarationLines()
        {
            var localDeclarationLines = this._lines.Where(line => Syntax.ParseStatement(line) is LocalDeclarationStatementSyntax);
            this.Clear();
            _lines.AddRange(localDeclarationLines);
        }

        private bool IsEmpty()
        {
            return !this._lines.Any();
        }
    }
}