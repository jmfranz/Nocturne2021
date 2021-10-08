using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareGuideSpill : ContextAwareGuide
{
    // Define string variables for Spill AwareGuide
    private string _mainRoomState;
    private string _teaRoomState;
    private string _fokthipurRoomState;
    private string _fokdoorwayState;

    // TODO: These need to be renamed
    private string _dogsRoomState;
    private string _securityroomState;
    private string _astronomyRoomState;

    // Define globals to make state comparison easier later in the script.
    const string MAINROOM = "MAINROOM";
    const string TEAROOM = "TEAROOM";
    const string FOKTHIPURROOM = "FOKTHIPURROOM";
    const string FOKDOORWAY = "FOKDOORWAY";

    // TODO: These need to be renamed as well.
    const string DOGSROOM = "DOGSROOM";
    const string ASTRONOMYROOM = "ASTRONOMYROOM";
    const string SECURITYROOM = "SECURITYROOM";

    const string LOCKPICKTAKENROOM = null;
    const string ACTIVEPARTICIPANTROOM = null;

    public override void UpdateGuideState(bool eventChange)
    {
        if (eventChange)
        {

            //TODO: Determine what "EventStatus" means and does....

            if (EventName == "Game Start" && EventStatus) // Game not started
            {
                // These may need to be updated to handle the "WRONG STATE" stuff...
                _teaRoomState = "Spill/TEA_ROOM_0";
                _fokthipurRoomState = "Spill/FOKTHIPUR_ROOM_0";
                _mainRoomState = "Spill/MAIN_ROOM_0";

            }

            /*
                ALL OF THESE STATES SHOULD BE TRIGGERED WHEN THE ACTIVE PLAYER SENDS THE ASSOCIATED EVENT

                This needs to be added to include a section that updates the state for each room.

                TODO: THIS STILL NEEDS TO BE TESTED!
            */
 
            else if(EventName == "Strike1" && EventStatus){ // Player has been given Strike 1
                string _strike1State = "Spill/RECEIVED_STRIKE_1";
                UpdateAwareGuideContent(_strike1State);
            }
            else if(EventName == "Strike2" && EventStatus){ // Player has been given Strike 2
                string _strike2State = "Spill/RECEIVED_STRIKE_2";
                UpdateAwareGuideContent(_strike2State);
            }
            else if(EventName == "Strike3" && !EventStatus){ // Player has been given Strike 3 
                string _strike3State = "Spill/RECEIVED_STRIKE_3";
                UpdateAwareGuideContent(_strike3State);
            }
            else if(EventName == "IntoCognitive" && !EventStatus){ // Player entered cognitive realm
                string _awareGuideContent = "Spill/ENTERED_COGNITIVE";
                UpdateAwareGuideContent(_awareGuideContent);
            }
            else if(EventName == "LearnedSecret" && !EventStatus){ // Player entered cognitive realm
                string _awareGuideContent = "Spill/LEARNED_SECRET";
                UpdateAwareGuideContent(_awareGuideContent);
            }
            else if(EventName == "TellFok" && !EventStatus){ // Fok is told
                string _awareGuideContent = "Spill/TELL_FOK";
                UpdateAwareGuideContent(_awareGuideContent);
            }
            else if(EventName == "TellCath" && !EventStatus){ // Cath is told
                string _awareGuideContent = "Spill/TELL_CATH";
                UpdateAwareGuideContent(_awareGuideContent);
            }
        }
        else // This is triggered (seemingly...) ONLY when a room change occurs.
        {

            if (EventName == "StoryStart" && !EventStatus) // Story has started -- Use the ALL_OTHER_SPACES audio
            {
                _astronomyRoomState = "Spill/ALL_OTHER_SPACES_0";
                _dogsRoomState = "Spill/ALL_OTHER_SPACES_0";
                _securityroomState = "Spill/ALL_OTHER_SPACES_0";
                _fokdoorwayState = "Spill/FOKTHIPUR_DOORWAY_0";

                // TODO: Rename these rooms based on spill landmarks, not standville -- HOW? We shall discuss.
                if (Room == ASTRONOMYROOM)
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
                if (Room == DOGSROOM)
                {
                    UpdateAwareGuideContent(_dogsRoomState);
                }
                if (Room == SECURITYROOM)
                {
                    UpdateAwareGuideContent(_securityroomState);
                }
                if (Room == FOKDOORWAY){
                    UpdateAwareGuideContent(_fokdoorwayState);
                }
            }
            else if(EventName == "TookLockPick" && !EventStatus){
                if(Room == LOCKPICKTAKENROOM){ // Ensure that passive player is in the room where the LOCK PICK was taken from.
                    string _awareGuideContent = "Spill/TEA_ROOM_1"; // TODO: Update to use room based state and interrupt.. ANYWHERE?
                    UpdateAwareGuideContent(_awareGuideContent);
                }
            }
            else if(EventName == "DoorUnlocked" && !EventStatus){
                if(Room == FOKDOORWAY){
                    _fokdoorwayState = "Spill/FOKTHIPUR_DOORWAY_1"; // TODO: Update to use room based state and interrupt..
                    UpdateAwareGuideContent(_fokdoorwayState);
                }
            }


            else if(EventName == "LeaveSame" && !EventStatus){
                if(Room == ACTIVEPARTICIPANTROOM){ // Ensure that PASSIVE player is in the same room as the ACTIVE player.
                    string _awareGuideContent = "Spill/LEAVE_0";
                    UpdateAwareGuideContent(_awareGuideContent);
                }
            }

            // Update room to last updated room state
            if(Room == MAINROOM){
                UpdateAwareGuideContent(_mainRoomState);
            }
            if(Room == TEAROOM){
                UpdateAwareGuideContent(_teaRoomState);
            }
            if (Room == FOKTHIPURROOM)
            {
                UpdateAwareGuideContent(_fokthipurRoomState);
            }

            // THESE HAVE NOT BEEN RENAMED YET... TODO: UPDATE
            if (Room == ASTRONOMYROOM)
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
            if (Room == DOGSROOM)
            {
                UpdateAwareGuideContent(_dogsRoomState);
            }
            if (Room == SECURITYROOM)
            {
                UpdateAwareGuideContent(_securityroomState);
            }

        }   
    }
}
