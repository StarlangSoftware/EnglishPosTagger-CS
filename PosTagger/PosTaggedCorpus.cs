using System;
using System.Collections.Generic;
using System.IO;
using Corpus;
using DataStructure;
using Dictionary.Dictionary;

namespace PosTagger
{
    public class PosTaggedCorpus : Corpus.Corpus
    {
        private readonly CounterHashMap<string> _tagList;

        /**
         * <summary>A constructor of {@link PosTaggedCorpus} which initializes the sentences of the corpus, the word list of
         * the corpus, and all possible tags.</summary>
         */
        public PosTaggedCorpus()
        {
            sentences = new List<Sentence>();
            wordList = new CounterHashMap<Word>();
            _tagList = new CounterHashMap<string>();
        }

        /**
         * <summary>A clone method for the {@link PosTaggedCorpus} class.</summary>
         *
         * <returns>A copy of the current {@link PosTaggedCorpus} class.</returns>
         */
        public new PosTaggedCorpus EmptyCopy()
        {
            return new PosTaggedCorpus();
        }

        /**
         * <summary>Another constructor of {@link PosTaggedCorpus} which takes a fileName of the corpus as an input, reads the
         * corpus from that file.</summary>
         *
         * <param name="fileName">Name of the corpus file.</param>
         */
        public PosTaggedCorpus(string fileName)
        {
            var newSentence = new Sentence();
            sentences = new List<Sentence>();
            _tagList = new CounterHashMap<string>();
            var streamReader = new StreamReader(fileName);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                var words = line.Split(new char[] { ' ', '\t'}, StringSplitOptions.None);
                foreach (var word in words)
                {
                    if (word != "")
                    {
                        if (word.Contains("/"))
                        {
                            var name = word.Substring(0, word.LastIndexOf('/'));
                            var tag = word.Substring(word.LastIndexOf('/') + 1);
                            string shortTag;
                            if (tag.Contains("+"))
                            {
                                shortTag = tag.Substring(0, tag.IndexOf("+", StringComparison.CurrentCulture));
                            }
                            else
                            {
                                if (tag.Contains("-"))
                                {
                                    shortTag = tag.Substring(0, tag.IndexOf("-", StringComparison.CurrentCulture));
                                }
                                else
                                {
                                    shortTag = tag;
                                }
                            }

                            _tagList.Put(shortTag);
                            newSentence.AddWord(new PosTaggedWord(name, shortTag));
                            if (tag == ".")
                            {
                                AddSentence(newSentence);
                                newSentence = new Sentence();
                            }
                        }
                    }
                }

                line = streamReader.ReadLine();
            }

            if (newSentence.WordCount() > 0)
            {
                AddSentence(newSentence);
            }
        }
        
        /**
         * <summary>getTagList returns all possible tags as a set.</summary>
         *
         * <returns>Set of all possible tags.</returns>
         */
        public HashSet<string> GetTagList(){
            return new HashSet<string>(_tagList.Keys);
        }

    }
}