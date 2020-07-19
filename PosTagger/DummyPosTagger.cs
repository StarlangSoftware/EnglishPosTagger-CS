using System;
using System.Linq;
using Corpus;

namespace PosTagger
{
    public class DummyPosTagger : PosTagger
    {
        private string[] _tagList;

        /**
         * <summary>Train method for the Dummy pos tagger. The algorithm gets all possible tag list.</summary>
         *
         * <param name="corpus">Training data for the tagger.</param>
         */
        public void Train(PosTaggedCorpus corpus)
        {
            var corpusTagList = corpus.GetTagList();
            _tagList = new string[corpusTagList.Count];
            _tagList = corpusTagList.ToArray();
        }

        /**
         * <summary>Test method for the Dummy pos tagger. For each word, the method chooses randomly a tag from all possible
         * tag list.</summary>
         *
         * <param name="sentence">Sentence to be tagged.</param>
         * <returns>Annotated (tagged) sentence.</returns>
         */
        public Sentence PosTag(Sentence sentence)
        {
            var random = new Random();
            var result = new Sentence();
            for (var i = 0; i < sentence.WordCount(); i++){
                result.AddWord(new PosTaggedWord(sentence.GetWord(i).GetName(), _tagList[random.Next(_tagList.Length)]));
            }
            return result;
        }
    }
}