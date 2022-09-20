namespace EgnApp.Validation
{
    public class EgnNumberValidation
    {
        private const int startingPartLength = 6;
        private const int middlePartLength = 3;
        private const int lastPartLength = 1;

        public bool IsValid(string egnNumber)
        {
            var firstDelimiter = egnNumber.IndexOf('-');
            var secondDelimiter = egnNumber.LastIndexOf('-');

            if (firstDelimiter == -1 || (firstDelimiter == secondDelimiter))
                throw new ArgumentException();

            var firstPart = egnNumber.Substring(0, firstDelimiter);
            if (firstPart.Length != startingPartLength)
                return false;

            var tempPart = egnNumber.Remove(0, startingPartLength + 1);
            var middlePart = tempPart.Substring(0, tempPart.IndexOf('-'));
            if (middlePart.Length != middlePartLength)
                return false;

            var lastPart = egnNumber.Substring(secondDelimiter + 1);
            if (lastPart.Length != lastPartLength)
                return false;

            return true;
        }
    }
}
