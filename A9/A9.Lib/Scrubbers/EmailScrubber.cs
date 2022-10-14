using System.Text.RegularExpressions;

namespace Logger
{
    public class EmailScrubber : AbstractScrubber
    {
        private EmailScrubber() { }

        private static EmailScrubber _Instance;

        public static EmailScrubber Instance => _Instance ?? (_Instance = new EmailScrubber());
        protected override Regex PIIRegEx => new Regex(@"[A-Za-z._]+\@[A-za-z]+\.(([A-za-z]+\.)*)?[A-za-z]+");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskLetters);
    }
}