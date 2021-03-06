using NUnit.Framework;
using PosTagger;

namespace Test
{
    public class HmmPosTaggerTest
    {
        [Test]
        public void TestPosTag()
        {
            PosTagger.PosTagger posTagger = new HmmPosTagger();
            var posTaggedCorpus = new PosTaggedCorpus("../../../brown.txt");
            posTagger.Train(posTaggedCorpus);
            int correct = 0, incorrect = 0;
            for (var i = 0; i < posTaggedCorpus.SentenceCount(); i++){
                var taggedSentence = posTagger.PosTag(posTaggedCorpus.GetSentence(i));
                for (var j = 0; j < taggedSentence.WordCount(); j++){
                    if (((PosTaggedWord) posTaggedCorpus.GetSentence(i).GetWord(j)).GetTag().Equals(((PosTaggedWord)taggedSentence.GetWord(j)).GetTag())){
                        correct++;
                    } else {
                        incorrect++;
                    }
                }
            }
            Assert.AreEqual(97.59, 100 * correct / (correct + incorrect + 0.0), 0.01);
        }

    }
}