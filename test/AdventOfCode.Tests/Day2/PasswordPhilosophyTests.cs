using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day2.Tests
{
    public class PasswordPhilosophyTests
    {
        private readonly string[] passwordsAndPoliciesDescriptions;

        private readonly string[] passwordsAndPoliciesDescriptionsExample = new string[]
        {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc",
        };

        public PasswordPhilosophyTests()
        {
            passwordsAndPoliciesDescriptions = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day2/input.txt"));
        }

        [Fact]
        public void ValidPasswordCount_1_With_PositionPolicy_For_Example()
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
        public void ValidPasswordCount_2_With_OccurencePolicy_For_Example()
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
        public void ValidPasswordCount_ShouldBe_474_With_OccurencePolicy()
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
        public void ValidPasswordCount_ShouldBe_745_With_PositionPolicy()
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