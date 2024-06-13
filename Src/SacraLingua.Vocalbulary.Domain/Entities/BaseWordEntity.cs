namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public abstract class BaseWordEntity<TEntity, TId, TEntityTranslation>
    {
        protected TId _id;
        public virtual TId Id => _id;
        public string Word { get; private set; }
        public string Sentence { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public IEnumerable<TEntityTranslation> Translations { get; set; }

        public BaseWordEntity(
            string word,
            string sentence,
            bool isDeleted)
        {
            Word = word;
            Sentence = sentence;
            IsDeleted = isDeleted;
        }

        public void MarkWordAsDeleted(BaseWordEntity<TEntity, TId, TEntityTranslation> word)
        {
            word.IsDeleted = true;
        }

        public void SetGreekWord(string word)
        {
            Word = word;
        }

        public void SetGreekWordSentence(string sentence)
        {
            Sentence = sentence;
        }
    }
}
