namespace SacraLingua.Vocalbulary.Domain.Exceptions
{
    public class DomainInvalidIdException : DomainValidationException
    {
        public DomainInvalidIdException(int id) :
            base($"An invalid value was specified for the Id field. Currnet value: {id}. Id have to be greater then 0") { }
    }
}
