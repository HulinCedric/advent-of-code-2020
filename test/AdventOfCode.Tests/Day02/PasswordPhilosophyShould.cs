using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day02.Tests
{
    public class PasswordPhilosophyShould
    {
        private readonly string[] passwordsAndPoliciesDescriptions;

        private readonly string[] passwordsAndPoliciesDescriptionsExample = new string[]
        {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc",
        };

        public PasswordPhilosophyShould()
        {
            passwordsAndPoliciesDescriptions = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day02/input.txt"));
        }

        [Fact]
        public void Have_1_valid_Password_with_PositionPolicy_for_example()
        {
            //Given
            var passwords = passwordsAndPoliciesDescriptionsExample.Select(description => PasswordFactory.CreatePasswordWithPositionPolicy(description));
            var expectedValidPasswordsCount = 1;

            //When
            var validPasswordsCount = passwords
                .Where(password => password.IsValid())
                .Count();

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }

        [Fact]
        public void Have_2_valid_Password_with_OccurencePolicy_for_example()
        {
            //Given
            var passwords = passwordsAndPoliciesDescriptionsExample.Select(description => PasswordFactory.CreatePasswordWithOccurrencePolicy(description));
            var expectedValidPasswordsCount = 2;

            //When
            var validPasswordsCount = passwords
                .Where(password => password.IsValid())
                .Count();

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }

        [Fact]
        public void Have_474_valid_Password_with_OccurencePolicy()
        {
            //Given
            var passwords = passwordsAndPoliciesDescriptions.Select(description => PasswordFactory.CreatePasswordWithOccurrencePolicy(description));
            var expectedValidPasswordsCount = 474;

            //When
            var validPasswordsCount = passwords
                .Where(password => password.IsValid())
                .Count();

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }

        [Fact]
        public void Have_745_valid_Password_with_PositionPolicy()
        {
            //Given
            var passwords = passwordsAndPoliciesDescriptions.Select(description => PasswordFactory.CreatePasswordWithPositionPolicy(description));
            var expectedValidPasswordsCount = 745;

            //When
            var validPasswordsCount = passwords
                .Where(password => password.IsValid())
                .Count();

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }
    }
}