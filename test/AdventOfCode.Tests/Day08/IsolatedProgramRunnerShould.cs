using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day08.Programs;
using Xunit;

namespace AdventOfCode.Day08
{
    public class IsolatedProgramRunnerShould
    {
        [Theory]
        [InlineData(ProgramDescription.ExampleDescription, 5)]
        [InputFileData("Day08/input.txt", 1548)]
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
        {
            var accumulator = 0;
            var executedInstructionsIndexes = new List<int>();
            var currentInstructionIndex = 0;

            do
            {
                if (executedInstructionsIndexes.Contains(currentInstructionIndex))
                    break;

                executedInstructionsIndexes.Add(currentInstructionIndex);

                var instruction = program.ElementAt(currentInstructionIndex);
                var executionResult = instruction.Execute(new ProgramContext(accumulator, currentInstructionIndex));

                accumulator = executionResult.AccumulatorValue;
                currentInstructionIndex = executionResult.NextInstructionIndex;

            } while (true);

            return new ProgramExecutionResult(accumulator);
        }
    }

    internal record ProgramExecutionResult(int AccumulatorValue);
}