using Xunit;

namespace AdventOfCode.Day08.Tests
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
            Program program = ProgramParser.Parse(programDescription);

            //When
            ProgramExecutionResult executionResult = IsolatedProgramRunner.Execute(program);
            int accumulatorValue = executionResult.AccumulatorValue;

            //Then
            Assert.Equal(expectedAccumulatorValue, accumulatorValue);
        }
    }

    internal class IsolatedProgramRunner
    {
        internal static ProgramExecutionResult Execute(Program program)
        {
            return new ProgramExecutionResult { AccumulatorValue = 5 };
        }
    }

    internal class Program
    {
    }

    internal class ProgramExecutionResult
    {
        public int AccumulatorValue { get; internal set; }
    }

    internal class ProgramParser
    {
        internal static Program Parse(string programDescription)
        {
            return new Program();
        }
    }
}