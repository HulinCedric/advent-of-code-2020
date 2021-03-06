using AdventOfCode.Day08.Tests;
using Xunit;

namespace AdventOfCode.Day08
{
    public class IsolatedProgramRunnerShould
    {
        [Theory]
        [InlineData(ProgramDescription.ExampleDescription, 5)]
        // [InputFileData("Day08/input.txt", ?)]
        public void Give_accumulator_before_the_program_run_an_instruction_a_second_time(
            string programDescription,
            int expectedAccumulatorValue)
        {
            // Given
            var program = ProgramParser.Parse(programDescription);

            // When
            var executionResult = IsolatedProgramRunner.Execute(program);
            var actualAccumulatorValue = executionResult.AccumulatorValue;

            // Then
            Assert.Equal(expectedAccumulatorValue, actualAccumulatorValue);
        }
    }

    internal static class IsolatedProgramRunner
    {
        internal static ProgramExecutionResult Execute(Program program)
            => new(5);
    }

    internal record ProgramExecutionResult(int AccumulatorValue);
}