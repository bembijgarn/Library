using LemondoDOMAIN;

namespace Lemondo.Interface
{
    public interface IBookActions
    {
        public BOOKS TakeBook(string BookName);
        public BOOKS ReturnBook(string BookName);
        public BOOKS FindBook(string BookName);
    }
}
