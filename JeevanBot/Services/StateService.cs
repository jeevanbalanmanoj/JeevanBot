using JeevanBot.Models;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeevanBot.Services
{
    public class StateService
    {

        #region Variables
        // State Variables
        public ConversationState ConversationState { get; }
        public UserState UserState { get; }

        // IDs
        public static string UserProfileId { get; } = $"{nameof(StateService)}.UserProfile";
        public static string ConversationDataId { get; } = $"{nameof(StateService)}.ConversationData";

        // Accessors
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }
        #endregion


        public StateService(ConversationState conversationState, UserState userState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));

            InitializeAccessors();
        }

        public void InitializeAccessors()
        {
            // Initialize Conversation State Accessors
             ConversationDataAccessor = ConversationState.CreateProperty<ConversationData>(ConversationDataId);

            // Initialize User State
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);

        }
    }
}