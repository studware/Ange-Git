
namespace CreaturesClassLib
{
    public interface ICommentable
    {
        string Comment { get; }

        void WriteComment(string text);
    }
}
