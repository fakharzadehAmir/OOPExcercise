using System.Text.RegularExpressions;

namespace Logger
{
    public class CCScrubber : AbstractScrubber
    {
        private CCScrubber() { }

        private static CCScrubber _Instance;

        public static CCScrubber Instance => _Instance ?? (_Instance = new CCScrubber());

        protected override Regex PIIRegEx => new Regex(@"\(?[0-9]{4}[-? ]?[0-9]{4}[-? ]?[0-9]{4}[-? ]?[0-9]{4}\)?");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskNumbers);
    }
}