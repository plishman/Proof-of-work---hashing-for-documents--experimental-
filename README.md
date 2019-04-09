# Proof of work - hashing for documents (experimental) - A suggested solution to fake news.

![Preview1](./pow.png)

<h2>Purpose</h2>
The purpose of this experimental program is to test the feasability of computing a salt string to add to any document which, when appended to the document, results in an MD5 hash having certain numerical characteristics - namely, that it should be exactly divisible by a user-selectable value.

This program creates an MD5 hash of a text which is exactly divisible by a user-selected value.

The program searches for an intelligible text string to append to the document to modify the document's MD5 hash such that the result of dividing the computed MD5 hash number by the user-selectable modulo is 0.

Since this computation can only be carried out by brute force search, higher modulo values result in longer computation times, which cannot be avoided. Thus this computation constitutes a proof of work.

<h2>A Solution to Fake News</h2>
This proof of work approach can be applied to real world news articles, to distinguish ephemeral commentary from works of significant resources and effort.

If an author stands by his work and has put great effort into producing it, hopefully he will be motivated to prove this by using a proof of work such as this. The more computation time (and therefore money) he is prepared to put into computing the proof of work, the more seriously he takes the work he has published.

This is important because the author (or anyone else) cannot then retrospectively alter the work without recomputing the proof of work hash, and in any case, such recomputation would be detectable, since it would alter the intelligible text string added to the document to make the hash value have the required characteristics.

