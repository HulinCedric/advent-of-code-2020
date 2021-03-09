using AdventOfCode.Day08.Programs;
using Xunit;

namespace AdventOfCode.Day08.Runners
{
    public class IsolatedProgramRunnerShould
    {
        [Theory]
        [InlineData(ProgramDescription.InfiniteLoopExampleDescription, 5)]
        [InputFileData("Day08/input.txt", 1548)]
        public void Give_accumulator_before_the_program_run_an_instruction_a_second_time(
            string programDescription,
            int expectedAccumulatorValue)
        {
            // Given
            var program = ProgramParser.Parse(programDescription);

            // When
            var executionResult = IsolatedProgramRunner.Execute(program);

            // Then
            Assert.Equal(expectedAccumulatorValue, executionResult.AccumulatorValue);
            Assert.True(executionResult.IsInfiniteLoop);
        }

        [Theory]
        [InlineData(ProgramDescription.TerminableExampleDescription, 8)]
        public void Give_accumulator_after_the_program_terminates(
            string programDescription,
            int expectedAccumulatorValue)
        {
            // Given
            var program = ProgramParser.Parse(programDescription);

            // When
            var executionResult = IsolatedProgramRunner.Execute(program);

            // Then
            Assert.Equal(expectedAccumulatorValue, executionResult.AccumulatorValue);
            Assert.True(executionResult.IsProgramTerminates);
        }
    }
}