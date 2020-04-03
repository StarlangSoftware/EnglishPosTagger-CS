using Dictionary.Dictionary;

namespace PosTagger
{
    public class PosTaggedWord : Word
    {
        private readonly string _tag;

        /**
         * <summary>A constructor of {@link PosTaggedWord} which takes name and tag as input and sets the corresponding attributes</summary>
         * <param name="name">Name of the word</param>
         * <param name="tag">Tag of the word</param>
         */
        public PosTaggedWord(string name, string tag) : base(name){
            this._tag = tag;
        }

        /**
         * <summary>Accessor method for tag attribute.</summary>
         *
         * <returns>Tag of the word.</returns>
         */
        public string GetTag(){
            return _tag;
        }

    }
}