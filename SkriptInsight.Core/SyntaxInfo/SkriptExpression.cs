using System.Diagnostics;

namespace SkriptInsight.Core.SyntaxInfo
{
    [DebuggerDisplay("{" + nameof(ClassName) + "}")]
    public class SkriptExpression : AbstractSyntaxElement
    {
        public virtual string ClassName { get; set; }

        public virtual string ReturnType { get; set; }

        public virtual ExpressionType ExpressionType { get; set; }
    }
}