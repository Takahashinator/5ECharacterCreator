using System;

namespace _5ECharacterCreator
{
    public class AssignmentException : Exception
    {
        public AssignmentException(string message)
            : base(message)
        {
        }
    }
}