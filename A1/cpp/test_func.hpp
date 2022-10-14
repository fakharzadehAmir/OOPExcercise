#include <string>
#include <vector>
#include <malloc.h>
#include "Library.cpp"
#include <cstdlib>
#include <fstream>
#include <sstream>
#include "Data.hpp"

using namespace std;

// std::vector<std::pair<std::string, std::vector<std::string> *>> *ReadFile(std::string fileName)
// {
//     auto fileOutput = new std::vector<
//         std::pair<
//             std::string, std::vector<std::string> *>>();
//     std::ifstream myFile(fileName.c_str());
//     if (!myFile.is_open())
//         throw std::runtime_error("Could not open file");
//     if (myFile.good())
//     {
//         std::string firstLineOut, colNameOut;
//         std::getline(myFile, firstLineOut);
//         std::stringstream ss(firstLineOut);
//         while (std::getline(ss, colNameOut, ','))
//             fileOutput->push_back({colNameOut, new std::vector<string>()});
//     }
//     std::string outLine;
//     while (std::getline(myFile, outLine))
//     {
//         std::stringstream ss(outLine);
//         int colIdx = 0;
//         std::string valueLineOut;
//         while (std::getline(ss, valueLineOut, ','))
//             fileOutput->at(colIdx++).second->push_back(valueLineOut);
//     }
//     myFile.close();
//     return fileOutput;
// }

// vector<A1::Book *> *GenerateBooks()
// {
//     auto fileOutput = ReadFile("books.csv");
//     int lineCount = ((*fileOutput)[0].second)->size();
//     auto books = new vector<A1::Book *>;
//     srand(1);
//     for (int line = 0; line < lineCount; line++)
//     {
//         std::string author = (*((*fileOutput)[2].second))[line];
//         std::string title = (*((*fileOutput)[1].second))[line];
//         int price = stoi((*((*fileOutput)[7].second))[line]);
//         float rating = stof((*((*fileOutput)[3].second))[line]);
//         std::string ISBN_10 = (*((*fileOutput)[4].second))[line];
//         std::string publishDate = (*((*fileOutput)[10].second))[line];
//         std::string category = Categories[rand() % Categories.size()];
//         A1::Book *book = new A1::Book(author, title, price, rating, ISBN_10, publishDate, category);
//         books->push_back(book);
//     }
//     return books;
// }

// vector<A1::Member *> *GenerateMembers()
// {
//     auto customers = new vector<A1::Member *>();
//     srand(1);
//     for (auto name : Names)
//     {
//         int tmp = rand();
//         customers->push_back(new A1::Member(tmp > 0 ? tmp : -1 * tmp, name));
//     }
//     return customers;
// }

// vector<size_t> *MembersMemoryLeak(vector<A1::Member *> *Members)
// {
//     vector<size_t> *sizes = new vector<size_t>;
//     for (auto member : *Members)
//     {
//         size_t size = _msize(member);
//         sizes->push_back(size);
//     }
//     return sizes;
// }

// bool TestBookEquality(A1::Book *book1, A1::Book *book2)
// {
//     return book1->GetTitle() == book2->GetTitle() &&
//            book1->GetPrice() == book2->GetPrice() &&
//            book1->GetRating() == book2->GetRating() &&
//            book1->GetCategory() == book2->GetCategory();
// }

// bool TestMemberEquality(A1::Member *member1, A1::Member *member2)
// {
//     bool nameAreEqual = member1->GetName() == member2->GetName();
//     bool savingMoneyAreEqual = member1->GetSavingMoney() == member2->GetSavingMoney();
//     return nameAreEqual && savingMoneyAreEqual && member1->IsBorrowed();
//     ;
// }

// vector<A1::Member *> *FindBorrowedPeople(vector<A1::Member *> *allMembers)
// {
//     vector<A1::Member *> *members = new vector<A1::Member *>;
//     for (A1::Member *member : *allMembers)
//         if (member->IsBorrowed())
//             members->push_back(member);
//     return members;
// }