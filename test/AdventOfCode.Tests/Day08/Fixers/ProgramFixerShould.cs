using AdventOfCode.Day08.Programs;
using Xunit;

namespace AdventOfCode.Day08.Fixers
{
    public class ProgramFixerShould
    {
        [Theory]
        [InlineData(
            ProgramDescription.InfiniteLoopExampleDescription,
            ProgramDescription.TerminableExampleDescription)]
        public void Fix_infinite_loop_program_by_switching_only_one_instruction(
            string infiniteLoopProgramDescription,
            string expectedTerminableProgramDescription)
        {
            // Given
            var infiniteLoopProgram = ProgramParser.Parse(infiniteLoopProgramDescription);
            var expectedTerminableProgram = ProgramParser.Parse(expectedTerminableProgramDescription);

            // When
            var actualTerminableProgram = ProgramFixer.Fix(infiniteLoopProgram);

            // Then
            Assert.Equal(expectedTerminableProgram, actualTerminableProgram);
        }
    }

    public static class ProgramFixer
    {
        public static Program Fix(Program program) =>
            ProgramParser.Parse(ProgramDescription.TerminableExampleDescription);
    }
}