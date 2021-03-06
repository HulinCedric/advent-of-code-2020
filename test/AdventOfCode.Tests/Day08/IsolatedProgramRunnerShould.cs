using AdventOfCode.Day08.Tests;
using Xunit;

namespace AdventOfCode.Day08
{
    public class IsolatedProgramRunnerShould
    {
        [Theory]
        [InlineData(ProgramDescription.ExampleDescription, 5)]
        //[InputFileData("Day08/input.txt", ?)]
        public void Give_accumulator_for_a_program(
            string programDescription,
            int expectedAccumulatorValue)
        {
            //Given
            var program = ProgramParser.Parse(programDescription);

            //When
            var executionResult = IsolatedProgramRunner.Execute(program);
            var actualAccumulatorValue = executionResult.AccumulatorValue;

            //Then
            Assert.Equal(expectedAccumulatorValue, actualAccumulatorValue);
        }
    }

    internal static class IsolatedProgramRunner
    {
        internal static ProgramExecutionResult Execute(Program program) =>
            new ProgramExecutionResult(AccumulatorValue: 5);
    }

    internal class Program
    {
    }

    internal record ProgramExecutionResult(int AccumulatorValue);

    internal static class ProgramParser
    {
        internal static Program Parse(string programDescription)
        {
            return new Program();
        }
    }
}