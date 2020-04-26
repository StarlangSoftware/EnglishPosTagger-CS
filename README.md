# EnglishPosTagger-CS

This is a tool meant for tagging words with their part-of-speech, a grammatical category based on their function within a sentence, such as noun, adjective, verb, and so forth. 

For Developers
============
You can also see [Java](https://github.com/starlangsoftware/EnglishPosTagger), [Python](https://github.com/starlangsoftware/EnglishPosTagger-Py), or [C++](https://github.com/starlangsoftware/EnglishPosTagger-CPP) repository.

Detailed Description
============
+ [PosTagger](#postagger)

## PosTagger

İngilizce pos tagging için kullanılan PosTagger'ı eğitmek için 

	void Train(PosTaggedCorpus corpus)
	
eğitilen PosTagger modelini kaydetmek için

	void SaveModel()
	
daha önce eğitilmiş bir PosTagger modelini yüklemek için

	void LoadModel()
	
ve yeni eğitilmiş veya yüklenmiş bir PosTagger modelini kullanarak bir cümleyi taglemek için

	Sentence PosTag(Sentence sentence)
	
metodu kullanılır.

3 farklı PosTagger modeli desteklenmektedir. Rasgele bir tag ile kelimeleri taglemek için kullanılan

	DummyPosTagger
	
o kelime için en çok kullanılan tag ile kelimeleri tagleyen

	NaivePosTagger
	
ve Hmm tabanlı bir eğitim yapıp buna göre kelimeleri tagleyen

	HmmPosTagger
