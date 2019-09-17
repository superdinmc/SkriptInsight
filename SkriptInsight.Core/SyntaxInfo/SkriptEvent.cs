using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using SkriptInsight.Core.Parser.Patterns;

namespace SkriptInsight.Core.SyntaxInfo
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class SkriptEvent : AbstractSyntaxElement
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string[] CurrentEventNames { get; set; }

        public string[] PastEventNames { get; set; }

        public string[] FutureEventNames { get; set; }

        public string[] Description { get; set; }

        public string[] Examples { get; set; }

        public string Since { get; set; }

        public string[] RequiredPlugins { get; set; }

        public string DocumentationId { get; set; }

        public string[] ClassNames { get; set; }

        public bool Cancellable { get; set; }

    }
}