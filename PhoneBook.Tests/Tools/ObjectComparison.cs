using System;
using System.Collections.Generic;
using PhoneBook.Domain;
using Xunit;

namespace PhoneBook.Tests.Tools
{
    public class ComparePhonebook
    {
        public static void Compare(IReadOnlyList<Phonebook> expected, IReadOnlyList<Phonebook> received)
        {
            Assert.Equal(expected.Count, received.Count);
            for (int i = 0; i < received.Count; i++)
            {
                Assert.Equal(expected[i].Id, received[i].Id);
                Assert.Equal(expected[i].Name, received[i].Name);
            }
        }
    }

    public class CompareEntry
    {
        public static void Compare(IReadOnlyList<Entry> expected, IReadOnlyList<Entry> received)
        {
            Assert.Equal(expected.Count, received.Count);
            for (int i = 0; i < received.Count; i++)
            {
                Assert.Equal(expected[i].Id, received[i].Id);
                Assert.Equal(expected[i].Name, received[i].Name);
                Assert.Equal(expected[i].Number, received[i].Number);
            }
        }
    }
}
