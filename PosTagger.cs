using Corpus;

namespace PosTagger
{
    public interface PosTagger
    {
        void Train(PosTaggedCorpus corpus);
        Sentence PosTag(Sentence sentence);
    }
}