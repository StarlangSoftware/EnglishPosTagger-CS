using System.Collections.Generic;
using Corpus;
using Dictionary.Dictionary;
using Hmm;

namespace PosTagger
{
    public class HmmPosTagger : PosTagger
    {
        private Hmm<string, Word> _hmm;

        /**
         * <summary>Train method for the Hmm pos tagger. The algorithm trains an Hmm from the corpus, where corpus constitutes
         * as an observation array.</summary>
         *
         * <param name="corpus">Training data for the tagger.</param>
         */
        public void Train(PosTaggedCorpus corpus)
        {
            var emittedSymbols = new List<string>[corpus.SentenceCount()];
            for (var i = 0; i < emittedSymbols.Length; i++){
                emittedSymbols[i] = new List<string>();
                for (var j = 0; j < corpus.GetSentence(i).WordCount(); j++){
                    var word = (PosTaggedWord) corpus.GetSentence(i).GetWord(j);
                    emittedSymbols[i].Add(word.GetTag());
                }
            }
            _hmm = new Hmm1<string, Word>(corpus.GetTagList(), emittedSymbols, corpus.GetAllWordsAsArray());
        }

        /**
         * <summary>Test method for the Hmm pos tagger. For each sentence, the method uses the viterbi algorithm to produce the
         * most possible state sequence for the given sentence.</summary>
         *
         * <param name="sentence">Sentence to be tagged.</param>
         * <returns>Annotated (tagged) sentence.</returns>
         */
        public Sentence PosTag(Sentence sentence)
        {
            var result = new Sentence();
            var tagList = _hmm.Viterbi(sentence.GetWords());
            for (var i = 0; i < sentence.WordCount(); i++){
                result.AddWord(new PosTaggedWord(sentence.GetWord(i).GetName(), tagList[i]));
            }
            return result;
        }
    }
}