using System;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class PrivacyScrubberTest 
    {
        [TestMethod]
        public void SinglePhoneNumberTest()
        {
            string piiNum = "(517)303-5279";
            string scrubbedPII = "(XXX)XXX-XXXX";
            string testString = $"My phone number is {piiNum}";
            string scrubbedString = $"My phone number is {scrubbedPII}";
            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void MultiplePhoneNumbersTest()
        {
            string pii1 = "(517)303-5279";
            string pii2 = "206-323-1212";
            string scrubbedPII1 = "(XXX)XXX-XXXX";
            string scrubbedPII2 = "XXX-XXX-XXXX";
            string testString = $"My phone number was {pii1} but it is {pii2} now";
            string scrubbedString = $"My phone number was {scrubbedPII1} but it is {scrubbedPII2} now";

            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void IDTest()
        {
            string testString = "Ali's SSN is  432-12-3232";
            string expectedString = "Ali's SSN is  XXX-XX-XXXX";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

            string testString1 = "My Id is 028-123456-0";
            string expectedString1 = "My Id is XXX-XXXXXX-X";

            string scrubbedString1 = IDScrubber.Instance.Scrub(testString1);
            Assert.AreEqual(scrubbedString1, expectedString1);
        }

        [TestMethod]
        public void FullNameTest()
        {
            string testString = "Mr. Bill Gates failed the exam.";
            string expectedString = "Xx. Xxxx Xxxxx failed the exam.";

            string maskedString = FullNameScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }
        [TestMethod]
        public void EmailTest()
        {
            string testString = $"My personal email is \"amirfakhazadeh@gmail.com\"";
            string expectedString = "My personal email is \"xxxxxxxxxxxxxx@xxxxx.xxx\"";

            string scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

            string testString1 = "My academy email is \"amir_fakharzadeh@comp.iust.ac.ir\"";
            string expectedString1 = "My academy email is \"xxxx_xxxxxxxxxxx@xxxx.xxxx.xx.xx\"";

            string scrubbedString1 = EmailScrubber.Instance.Scrub(testString1);
            Assert.AreEqual(scrubbedString1, expectedString1);
        }
        [TestMethod]
        public void CCTest()
        {
            string testString = $"My CC is 1234-5678-1234-5678";
            string expectedString = "My CC is XXXX-XXXX-XXXX-XXXX";

            string scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

            string testString1 = "My CC is 1234 5678 1234 5678";
            string expectedString1 = "My CC is XXXX XXXX XXXX XXXX";

            string scrubbedString1 = CCScrubber.Instance.Scrub(testString1);
            Assert.AreEqual(scrubbedString1, expectedString1);

            string testString2 = "My CC is 1234567812345678";
            string expectedString2 = "My CC is XXXXXXXXXXXXXXXX";

            string scrubbedString2 = CCScrubber.Instance.Scrub(testString2);
            Assert.AreEqual(scrubbedString2, expectedString2);

            string testString3 = "My CC is (1234 5678 1234 5678)";
            string expectedString3 = "My CC is (XXXX XXXX XXXX XXXX)";

            string scrubbedString3 = CCScrubber.Instance.Scrub(testString3);
            Assert.AreEqual(scrubbedString3, expectedString3);
        }

    }

}
