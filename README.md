For Developers
============

You can also see [Java](https://github.com/starlangsoftware/EnglishPosTagger), [Python](https://github.com/starlangsoftware/EnglishPosTagger-Py), [Cython](https://github.com/starlangsoftware/EnglishPosTagger-Cy), [Swift](https://github.com/starlangsoftware/EnglishPosTagger-Swift), or [C++](https://github.com/starlangsoftware/EnglishPosTagger-CPP) repository.

Detailed Description
============

+ [PosTagger](#postagger)

## PosTagger

To train the PosTagger which is used for English pos tagging 

	void Train(PosTaggedCorpus corpus)
	
To save the trained PosTagger model

	void SaveModel()
	
To load an already trained PosTagger model

	void LoadModel()
	
To tag a sentence, using a newly trained or loaded PosTagger model

	Sentence PosTag(Sentence sentence)
	
3 different PosTagger models are supported: The one that is used to tag the sentences with a random tag

	DummyPosTagger
	
the one that tags the word with the most used tag for a given word

	NaivePosTagger
	
the one that does an Hmm based training and tags the words accordingly

	HmmPosTagger
