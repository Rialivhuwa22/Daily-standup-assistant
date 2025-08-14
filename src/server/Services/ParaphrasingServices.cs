using OpenAI.Interfaces;// allow for the use of openAI services
using OpenAI.ObjectModels.RequestModels;//structure the request you send to openAI


namespace server.Services 
{
    public class ParaphrasingServices // this class handles the paraphrasing notes using openAI's chat service
    {  
        //store the openAI service so we can use it in other methods 
        private readonly IOpenAIService _openAIService;

        public ParaphrasingServices(IOpenAIService openAIService) // constructor class: receives the openAI service and saves it for later use
        {
            _openAIService = openAIService;
        }

        
        public async Task<string> ParaphraseAsync(string notes)// this async method takes some notes as an input and returns a paraphrased version
        {
            try
            {
                //prepare the conversation messages to send to openAI
                var messages = new List<ChatMessage>
                {
                    // tell the AI its role- a helpful assistant rewriting notes professionally
                    ChatMessage.FromSystem("You are a helpful assistant that rewrites daily standup notes in a professional and expanded way."),
                    
                    //give the AI the notes to paraphrase (the user message)
                    ChatMessage.FromUser($"Paraphrase and expand the following notes:\n\n{notes}")
                };
                // Build the request specifying model, messages, creativity, and max response length
                var chatRequest = new ChatCompletionCreateRequest
                {
                    Messages = messages,
                    Model = OpenAI.ObjectModels.Models.Gpt_3_5_Turbo,
                    Temperature = 0.7f,
                    MaxTokens = 400
                };
                // Send the request to OpenAI and wait for the response asynchronously
                var response = await _openAIService.ChatCompletion.CreateCompletion(chatRequest);
                
                // If the call was successful and we got at least one reply
                if (response.Successful && response.Choices != null && response.Choices.Count > 0)
                {
                    // Return the first reply’s text after trimming whitespace
                    return response.Choices.First().Message.Content.Trim();
                }

                // If not successful, return the error message from the response
                return $"Failed to generate response. Error: {response.Error?.Message ?? "Unknown error."}";
            }
            catch (Exception ex)
            {
                // If something went wrong (exception), return the exception message
                return $"Exception occurred: {ex.Message}";
            }
        }
    }
}