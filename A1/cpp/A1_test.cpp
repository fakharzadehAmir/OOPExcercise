#define CATCH_CONFIG_MAIN
#include "test_func.hpp"
#include "Library.cpp"
#include "catch.hpp"
using namespace A1;
TEST_CASE("Book Constructor", "[Making Books]")
{
    SECTION("Default Constructor")
    {
        Book book;
    }

    SECTION("Book Constructor, Getter, Setter")
    {
        // use initializer list // designated initializers
        Book book({.Author = "Amirhosein", .Title = "Clean Coding", .Price = 1'000'000L, .Rating = 3.5f, .ISBN_10 = "1494932636", .PublishDate = "13-02-2014", .Category = "Software Development"});
        SECTION("Copy Constructor")
        {
            // use this pointer
            Book book2(book);
        }
        SECTION("Book Getter, Setter")
        {
            REQUIRE(book.GetAuthor() == "Amirhosein");
            REQUIRE(book.GetTitle() == "Clean Coding");
            REQUIRE(book.GetPrice() == 1000000);
            REQUIRE(book.GetRating() == Approx(3.5));
            SECTION("Increase the Price")
            {
                // roundup 2 digits
                int NewPrice = 10'01;
                book.SetPrice(NewPrice);
                REQUIRE(book.GetPrice() == 1100);
                NewPrice = 10'26;
                book.SetPrice(NewPrice);
                REQUIRE(book.GetPrice() == 1100);
                NewPrice = 11'49;
                book.SetPrice(NewPrice);
                REQUIRE(book.GetPrice() == 1200);
                NewPrice = 11'00;
                book.SetPrice(NewPrice);
                REQUIRE(book.GetPrice() == 1100);
                Book book2("Ben Clark", "Red Team Field Manual", 9, 4.6, "978-1494295509", "05-10-2015", "Security & Encryption");
                REQUIRE(book2.GetPrice() == 100);
            }
            SECTION("Change Rating")
            {
                // 1 - 5 stars
                book.SetRating(5.5);
                REQUIRE(book.GetRating() == 3.5);
                book.SetRating(-5.5);
                REQUIRE(book.GetRating() == 3.5);
                book.SetRating(0.5);
                REQUIRE(book.GetRating() == 3.5);
                book.SetRating(1.5);
                REQUIRE(book.GetRating() == 1.5);
            }
        }
    }
}

// TEST_CASE("Library Constructor, Destructor, Getter, Setter", "[Making Library]")
// {
//     SECTION("Default Constructor")
//     {
//         Library lib;
//     }
//     SECTION("Parameter Constructor")
//     {
//         // use initializer list // designated initializers
//         Library lib("Boston Public Library"); // Name
//     }
//     SECTION("Add New Book to Library")
//     {
//         Library lib("Boston Public Library"); // Name
//         lib.AddBook(new Book("Ben Clark",
//                              "Red Team Field Manual",
//                              9,
//                              4.6,
//                              "978-1494295509",
//                              "05-10-2015",
//                              "Security & Encryption"));
//     }
//     SECTION("Library Getter, Setter ")
//     {
//         Library lib("Boston Public Library"); // Name
//         lib.AddBook(new Book("Ben Clark",
//                              "Red Team Field Manual",
//                              9,
//                              4.6,
//                              "978-1494295509",
//                              "05-10-2015",
//                              "Security & Encryption"));
//         Library lib3("New York Public Library");
//         REQUIRE(lib.GetName() == "Boston Public Library");
//         REQUIRE_FALSE(lib.GetAllBooks() == nullptr);
//         REQUIRE(lib.GetAllBooks()->size() == 1);
//         lib3.SetName("Brooklyn Public Library");
//         REQUIRE(lib3.GetName() == "Brooklyn Public Library");
//     }
//     SECTION("Library Copy Constructor ")
//     {
//         // use this pointer
//         // copy books // use new operator
//         Library lib("Boston Public Library"); // Name
//         lib.AddBook(new Book("Ben Clark",
//                              "Red Team Field Manual",
//                              9,
//                              4.6,
//                              "978-1494295509",
//                              "05-10-2015",
//                              "Security & Encryption"));
//         Library lib2(lib);
//         REQUIRE_FALSE(lib2.GetName() == lib.GetName());
//         REQUIRE(lib2.GetAllBooks() != nullptr);
//         REQUIRE_FALSE(lib.GetAllBooks() == lib2.GetAllBooks());
//     }
// }

/*
    Baraye Azure in ghesmat bayad comment shavad
    zira dar azure pass nakhahad shod
    *** Memory Leak ba estefade az in test moshakhas mishavad ***
    *** In GHesmat dasti check khahad shod ***
    *** agar az piade sazi motmaen hastid va code shoma error midahad test ra chand bar run konid ***
*/
// TEST_CASE("Memory Leak Checking")
// {
//     Library lib("Boston Public Library"); // Name
//     lib.AddBook(new Book("Ben Clark",
//                          "Red Team Field Manual",
//                          9,
//                          4.6,
//                          "978-1494295509",
//                          "05-10-2015",
//                          "Security & Encryption"));

//     Library lib2(lib);
//     vector<Book *> *PtrLeak1 = lib2.GetAllBooks();
//     size_t size1 = _msize(PtrLeak1);
//     size_t AllocMEM = sizeof(*PtrLeak1);
//     lib2.~Library();
//     vector<Book *> *PtrLeak2 = lib2.GetAllBooks();
//     size_t size2 = _msize(PtrLeak1);
//     REQUIRE(PtrLeak2 == nullptr);
//     REQUIRE(size1 == AllocMEM);
//     REQUIRE_FALSE(size2 == AllocMEM);
// }

// TEST_CASE("Member", "[Member Ctor]")
// {
//     SECTION("Default, Copy, Parameter CTOR for Members")
//     {
//         Member c1;
//         Member c2(1'000'000, "Mahdi");
//         Member c3(c2); // same money
//         REQUIRE(c3.GetSavingMoney() == c2.GetSavingMoney());
//         REQUIRE_FALSE(c3.GetName() == c2.GetName());
//     }
// }

// TEST_CASE("Registeration", "[Library Registration]")
// {
//     Member *c1 = new Member(1'000'000, "Phoebe");
//     Member *c2 = new Member(100, "Chandler");
//     Member *c3 = new Member(2'000, "Joey ");
//     Member *c4 = new Member(50'000, "Gunther");
//     Library lib("Boston Public Library");

//     SECTION("Register Members")
//     {
//         vector<Member *> *ptr = lib.GetAllMembers();
//         lib.RegisterMember(c1);
//         lib.RegisterMember(c2);
//         lib.RegisterMember(c3);
//         lib.RegisterMember(c4);
//         REQUIRE(c1->GetSavingMoney() == 999'000);
//         REQUIRE(c2->GetSavingMoney() == 100);
//         REQUIRE(c3->GetSavingMoney() == 1'000);
//         REQUIRE(c4->GetSavingMoney() == 49'000);
//     }
// }

/*
    Baraye Azure in ghesmat bayad comment shavad
    zira dar azure pass nakhahad shod
    *** function MembersMemoryLeak dar file test_func.hpp ra az comment dar biavarid ***
    *** Memory Leak ba estefade az in test moshakhas mishavad ***
    *** In GHesmat dasti check khahad shod ***
    *** agar az piade sazi motmaen hastid va code shoma error midahad test ra chand bar run konid ***
    
*/
// TEST_CASE("Library Memory Leak", "[Memory Leak]")
// {
//     Member *c1 = new Member(1'000'000, "Phoebe");
//     Member *c2 = new Member(100, "Chandler");
//     Member *c3 = new Member(2'000, "Joey ");
//     Member *c4 = new Member(50'000, "Gunther");
//     Library lib("Boston Public Library");
//     lib.RegisterMember(c1);
//     lib.RegisterMember(c2);
//     lib.RegisterMember(c3);
//     lib.RegisterMember(c4);

//     vector<Member *> *PtrLeak1 = lib.GetAllMembers();
//     vector<size_t> *sizes1 = MembersMemoryLeak(PtrLeak1);
//     size_t size1 = _msize(PtrLeak1);
//     size_t AllocMEM = sizeof(*PtrLeak1);
//     lib.~Library();
//     vector<Member *> *PtrLeak2 = lib.GetAllMembers();
//     vector<size_t> *sizes2 = MembersMemoryLeak(PtrLeak1);
//     size_t size2 = _msize(PtrLeak1);
//     REQUIRE(PtrLeak2 == nullptr);
//     REQUIRE(size1 == AllocMEM);
//     REQUIRE_FALSE(size2 == AllocMEM);
//     for (int idx = 0; idx < sizes1->size(); idx++)
//         REQUIRE_FALSE((*sizes1)[idx] == (*sizes2)[idx]);
//     delete sizes1;
//     delete sizes2;
// }

// TEST_CASE("Library Features", "[Sort, borrow]")
// {
//     Library lib("Boston Public Library");
//     for (Member *customer : *GenerateMembers())
//         lib.RegisterMember(customer);
//     SECTION("sort all the people registered in library alphabetically")
//     {
//         lib.SortMembersByName();
//         vector<Member *> *Members = lib.GetAllMembers();
//         vector<Member *> SortedMembers(*Members);
//         // Const Correctness, Accessor
//         std::sort(SortedMembers.begin(), SortedMembers.end(), [](const Member *lhs, const Member *rhs) { return lhs->GetName() < rhs->GetName(); });
//         for (int idx = 0; idx < SortedMembers.size(); idx++)
//             REQUIRE(((SortedMembers[idx]->GetName() == (*Members)[idx]->GetName()) &&
//                      (SortedMembers[idx]->GetSavingMoney() == (*Members)[idx]->GetSavingMoney())));
//     }
//     for (Book *book : *GenerateBooks())
//         lib.AddBook(book);
//     vector<Member *> *allMembers = lib.GetAllMembers();
//     vector<Book *> *allBooks = lib.GetAllBooks();
//     srand(rand());
//     SECTION("Borrow Books")
//     {
//         for (int i = 0; i < 20; i++)
//             lib.BorrowBook((*allBooks)[rand() % allBooks->size()],
//                            (*allMembers)[rand() % allMembers->size()]);
//         vector<Member *> *borrowedPeople = FindBorrowedPeople(allMembers);
//         Member *member = new Member(10453, "Ermaya");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(0), member));
//         delete member;
//         member = new Member(28258, "Arthur");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(1), member));
//         delete member;
//         member = new Member(4397, "Samuel");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(2), member));
//         delete member;
//         member = new Member(13721, "Joseph");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(3), member));
//         lib.DaysPassed(100);
//         delete member;
//         member = new Member(9453, "Ermaya");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(0), member));
//         delete member;
//         member = new Member(24258, "Arthur");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(1), member));
//         delete member;
//         member = new Member(2397, "Samuel");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(2), member));
//         delete member;
//         member = new Member(11721, "Joseph");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(3), member));
//         lib.DaysPassed(100);
//         delete member;
//         member = new Member(8453, "Ermaya");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(0), member));
//         delete member;
//         member = new Member(20258, "Arthur");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(1), member));
//         delete member;
//         member = new Member(397, "Samuel");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(2), member));
//         delete member;
//         member = new Member(9721, "Joseph");
//         REQUIRE(TestMemberEquality(borrowedPeople->at(3), member));
//         delete member;
//     }
//     vector<Book *> *favotireBooks1;
//     vector<Book *> *favotireBooks2;
//     vector<Book *> *favotireBooks3;
//     SECTION("Books with your favorite Category and Score")
//     {
//         // category contains and lower cased // rating
//         favotireBooks1 = lib.FindBooks("Horror", 4);
//         favotireBooks2 = lib.FindBooks("horror", 4);
//         favotireBooks3 = lib.FindBooks("hor", 4);
//         // we didn't free theses books and this code has memory Leak :)
//         for (int idx = 0; idx < favotireBooks1->size(); ++idx)
//         {
//             Book *book1 = (*favotireBooks1)[idx];
//             Book *book2 = (*favotireBooks2)[idx];
//             Book *book3 = (*favotireBooks3)[idx];
//             REQUIRE(
//                 (TestBookEquality(book1, book2) &&
//                  TestBookEquality(book1, book3)));
//         }
//         REQUIRE(((*favotireBooks1)[0]->GetTitle() == "Harry Potter Collection (Harry Potter  #1-6)"));
//         REQUIRE(((*favotireBooks1)[1]->GetTitle() == "The Ultimate Hitchhiker's Guide: Five Complete Novels and One Story (Hitchhiker's Guide to the Galaxy  #1-5)"));
//         REQUIRE(((*favotireBooks1)[2]->GetTitle() == "Molly Hatchet - 5 of the Best"));
//     }
// }