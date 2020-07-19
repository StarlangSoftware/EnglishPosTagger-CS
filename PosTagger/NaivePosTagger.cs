using System.Collections.Generic;
using Corpus;
using DataStructure;

namespace PosTagger
{
    public class NaivePosTagger : PosTagger
    {
        private Dictionary<string, string> _maxMap;

        /**
         * <summary>Train method for the Naive pos tagger. The algorithm gets all possible tag list. Then counts all
         * possible tags (with its counts) for each possible word.</summary>
         *
         * <param name="corpus">Training data for the tagger.</param>
         */
        public void Train(PosTaggedCorpus corpus)
        {
            var map = new Dictionary<string, CounterHashMap<string>>();
            for (var i = 0; i < corpus.SentenceCount(); i++){
                var s = corpus.GetSentence(i);
                for (var j = 0; j < s.WordCount(); j++){
                    var word = (PosTaggedWord) corpus.GetSentence(i).GetWord(j);
                    if (map.ContainsKey(word.GetName())){
                        map[word.GetName()].Put(word.GetTag());
                    } else {
                        var counterMap = new CounterHashMap<string>();
                        counterMap.Put(word.GetTag());
                        map[word.GetName()] = counterMap;
                    }
                }
            }
            _maxMap = new Dictionary<string, string>();
            foreach (var word in map.Keys){
                _maxMap[word] = map[word].Max();
            }
        }

        /**
         * <summary>Test method for the Naive pos tagger. For each word, the method chooses the maximum a posterior tag from all
         * possible tag list for that word.</summary>
         *
         * <param name="sentence">Sentence to be tagged.</param>
         * <returns>Annotated (tagged) sentence.</returns>
         */
        public Sentence PosTag(Sentence sentence)
        {
            var result = new Sentence();
            for (var i = 0; i < sentence.WordCount(); i++){
                result.AddWord(new PosTaggedWord(sentence.GetWord(i).GetName(), _maxMap[sentence.GetWord(i).GetName()]));
            }
            return result;
        }
    }
}