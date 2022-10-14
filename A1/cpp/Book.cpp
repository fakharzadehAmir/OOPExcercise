#pragma once
#include "Member.cpp"

namespace A1{
class Book 
{
public:
    Book(){}
    Book(string Author ,string Title ,long int Price ,float Rating , string ISBN_10 , string PublishDate , string Category )
    : Author(Author)
    , Title(Title)
    , Price(Price)
    , Rating(Rating)
    , ISBN_10(ISBN_10)
    , PublishDate(PublishDate)
    , Category(Category)
    {SetRating(Rating);SetPrice(Price);}
    Book(const Book& other)
    {
        this->Author = other.Author;
        this->Title = other.Title;
        this->Price = other.Price;
        this->Rating = other.Rating;
        this->ISBN_10 = other.ISBN_10;
        this->PublishDate = other.PublishDate;
        this->Category = other.Category;
    }
    string GetAuthor(){return Author;}
    string GetTitle(){return Title;}
    long int GetPrice(){return Price;}
    float GetRating(){return Rating;}
    string GetCategory(){return Category;}
    string GetPublishDate(){return PublishDate;}
    string GetISBN_10(){return ISBN_10;}
    void SetRating(float new_rate){if (new_rate > 1 && new_rate < 5) this->Rating = new_rate;}
    void SetPrice(long int new_price)
    {
        int rem = new_price%100;
        if (rem>0) this->Price =  new_price-rem+100;
        else this->Price = new_price;
    }
    string Author;
    string Title;
    long int Price;
    float Rating;
    string ISBN_10;
    string PublishDate;
    string Category;
};
}