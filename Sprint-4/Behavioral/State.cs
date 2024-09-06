using System;

namespace DocumentWorkflow
{
    // State Interface
    public interface IDocumentState
    {
        void Publish(Document context);
    }

    // Draft State
    public class DraftState : IDocumentState
    {
        public void Publish(Document context)
        {
            Console.WriteLine("Document submitted for moderation.");
            context.SetState(new ModerationState());
        }
    }

    // Moderation State
    public class ModerationState : IDocumentState
    {
        public void Publish(Document context)
        {
            Console.WriteLine("Document approved and published.");
            context.SetState(new PublishedState());
        }
    }

    // Published State
    public class PublishedState : IDocumentState
    {
        public void Publish(Document context)
        {
            Console.WriteLine("Document is already published.");
        }
    }

    // Context Class
    public class Document
    {
        private IDocumentState _state;

        public Document()
        {
            _state = new DraftState(); // Default state
        }

        public void SetState(IDocumentState state)
        {
            _state = state;
        }

        public void Publish()
        {
            _state.Publish(this);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();

            // Start in Draft state
            document.Publish();  // Output: Document submitted for moderation.

            // Move to Moderation state and publish
            document.Publish();  // Output: Document approved and published.

            // Try publishing again in Published state
            document.Publish();  // Output: Document is already published.
        }
    }
}
