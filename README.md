# SacraLingua.Vocalbulary

## Project status - In Progress

## About Project
With this API, the client can retrieve information about ancient languages such as Greek and Hebrew. Each word and phrase is retrieved from the Bible.
For the moment, along with the word, the client can also download the English and Polish translation.

## API methods:
|HTTP Method|Endpoint|Description|
|--|----|-------|
|GET|/greek-words/|Get list of greek words based on query criteria|
|POST|/greek-words/|Add new greek word with list of translations|
|GET|/greek-words/{id}|Get single greek word thanks to its id|

## Technologies and patterns
* Onion Architecture
* .NET Core
* Entity Framework
* Custom Exception Middleware
* XUnit (for Unit tests and Integration tests)
