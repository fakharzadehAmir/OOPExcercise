namespace Logger
{
    public static class PrivacyScrubberFactory
    {
        public static IPrivacyScrubber ScrubAll() => new PrivacyScrubber(
                PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                FullNameScrubber.Instance,
                EmailScrubber.Instance,
                CCScrubber.Instance
            );
            public static IPrivacyScrubber NullScrub() => new PrivacyScrubber();
        public static IPrivacyScrubber ScrubLetters() => new PrivacyScrubber(
            FullNameScrubber.Instance,
            EmailScrubber.Instance
        );

        public static IPrivacyScrubber ScrubNumbers() => new PrivacyScrubber(
            PhoneNumberScrubber.Instance,
            IDScrubber.Instance,
            CCScrubber.Instance
        );
    }
}