using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace AdventOfCode
{
    public class InputFileDataAttribute : DataAttribute
    {
        private readonly object expected;
        private readonly string filePath;

        /// <summary>
        /// Load data from a input file as the data source for a theory.
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the input file to load.</param>
        /// <param name="expected">The expected value.</param>
        public InputFileDataAttribute(
            string filePath,
            object expected)
        {
            this.filePath = filePath;
            this.expected = expected;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            // Get the absolute path to the input file
            var path = Path.IsPathRooted(filePath)
                ? filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            yield return new[]
            {
                GetFileContent(filePath),
                expected,
            };
        }

        /// <summary>
        /// Gets the content of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The file content.</returns>
        /// <remarks>
        /// All lines in file are separated by a LF (Line Feed) for normalization purpose.
        /// </remarks>
        private static string GetFileContent(string filePath)
            => string.Join(
                "\n",
                File.ReadAllLines(filePath));
    }
}