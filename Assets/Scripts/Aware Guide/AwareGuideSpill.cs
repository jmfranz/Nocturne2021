using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareGuideSpill : ContextAwareGuide
{
    // Define string variables for Spill AwareGuide
    private string _mainRoomState; // Tea Table
    private string _teaRoomState; // Tea Table
    private string _fokthipurRoomState;
    private string _fokdoorwayState;
    private string _emptyRoomState;
    private string _windowEmptyRoomState;
    private string _circlesRoomState; // Tea Table

    // Define globals to make state comparison easier later in the script.
    const string MAINROOM = "MAINROOM"; // Tea Table
    const string TEAROOM = "TEAROOM"; // Tea Table
    const string FOKTHIPURROOM = "FOKTHIPURROOM";
    const string FOKDOORWAY = "FOKDOORWAY";
    const string EMPTYROOM = "EMPTYROOM";
    const string WINDOWEMPTYROOM = "WINDOWEMPTYROOM";
    const string CIRCLESROOM = "CIRCLESROOM"; // Tea Table

    const string LOCKPICKTAKENROOM = null;
    const string ACTIVEPARTICIPANTROOM = null;

    public override void UpdateGuideState(bool eventChange)
    {
        if (eventChange)
        {
            if (EventName == "Game Start" && EventStatus) // Game not started
            {
                // This may need to be updated to handle the "WRONG STATE", but there is no such content in the AwareGuide script? Temp using the ALL OTHER SPACES content.
                //TODO: Address or remove comments
                _windowEmptyRoomState = "Spill/ALL_OTHER_SPACES_0";
                _emptyRoomState = "Spill/ALL_OTHER_SPACES_0";
                _teaRoomState = "Spill/ALL_OTHER_SPACES_0";
                _circlesRoomState = "Spill/ALL_OTHER_SPACES_0";
                _fokdoorwayState = "Spill/ALL_OTHER_SPACES_0";
                _fokthipurRoomState = "Spill/ALL_OTHER_SPACES_0";
                _mainRoomState = "Spill/MAIN_ROOM_0";

            }

            else if (EventName == "Game Start" && !EventStatus) // Story has started
            {
                _windowEmptyRoomState = "Spill/ALL_OTHER_SPACES_0";
                _emptyRoomState = "Spill/ALL_OTHER_SPACES_0";
                _teaRoomState = "Spill/TEA_ROOM_0";
                _circlesRoomState = "Spill/TEA_ROOM_0";
                _fokdoorwayState = "Spill/ALL_OTHER_SPACEAS_0";
                _fokthipurRoomState = "Spill/FOKTHIPUR_ROOM_0";
                _mainRoomState = "Spill/MAIN_ROOM_0";

                if (Room == WINDOWEMPTYROOM){
                    UpdateAwareGuideContent(_windowEmptyRoomState);
                }
                if (Room == EMPTYROOM){
                    UpdateAwareGuideContent(_emptyRoomState);
                }
                if (Room == TEAROOM){
                    UpdateAwareGuideContent(_teaRoomState);
                }
                if (Room == CIRCLESROOM){
                    UpdateAwareGuideContent(_circlesRoomState);
                }
                if (Room == FOKDOORWAY){
                    UpdateAwareGuideContent(_fokdoorwayState);
                }
                if (Room == FOKTHIPURROOM){
                    UpdateAwareGuideContent(_fokthipurRoomState);
                }
                if (Room == MAINROOM){
                    UpdateAwareGuideContent(_mainRoomState);
                }
            }

            /*
                ALL OF THESE STATES SHOULD BE TRIGGERED WHEN THE ACTIVE PLAYER SENDS THE ASSOCIATED EVENT
                TODO: THIS STILL NEEDS TO BE TESTED!
            */


            /* Handle the three different strikes logic, none of these are room specific according to the script */
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


            /* Interrupt for the TookLockpick Event */
            else if(EventName == "TookLockpick" && EventStatus){
                // This is not room specifc, so simply update the Aware guide
                string _awareGuideContent = "Spill/TEA_ROOM_1";
                UpdateAwareGuideContent(_awareGuideContent);
            }

            
            /* Handle the Hallway event for DoorUnlocked*/
            else if(EventName == "DoorUnlocked" && !EventStatus){
                _fokdoorwayState = "Spill/FOKTHIPUR_DOORWAY_1"; // TODO: Update to use room based state and interrupt..
                if(Room == FOKDOORWAY){
                    UpdateAwareGuideContent(_fokdoorwayState);
                }
            }


            /* Handle the event for in Foks Room*/
            else if(EventName == "InFoksRoom" && !EventStatus){
                _fokthipurRoomState = "Spill/FOKTHIPUR_ROOM_0"; // TODO: Update to use room based state and interrupt..
                if(Room == FOKTHIPURROOM){
                    UpdateAwareGuideContent(_fokthipurRoomState);
                }
            }


            /* Handles the Into Cognitive and LearnedSceret events*/
            else if(EventName == "IntoCognitive" && EventStatus){ // Player entered cognitive realm
                // This is not room specifc, so simply update the Aware guide
                string _awareGuideContent = "Spill/ENTERED_COGNITIVE";
                UpdateAwareGuideContent(_awareGuideContent);
            }
            else if(EventName == "LearnedSecret" && !EventStatus){ // Player entered cognitive realm
                // This is not room specifc, so simply update the Aware guide
                string _awareGuideContent = "Spill/LEARNED_SECRET";
                UpdateAwareGuideContent(_awareGuideContent);
            }


            /*Handles the "Telling" events*/
            else if(EventName == "TellFok" && !EventStatus){ // Fok is told
                // This is not room specifc, so simply update the Aware guide
                string _awareGuideContent = "Spill/TELL_FOK";
                UpdateAwareGuideContent(_awareGuideContent);
            }
            else if(EventName == "TellCath" && !EventStatus){ // Cath is told
                // This is not room specifc, so simply update the Aware guide
                string _awareGuideContent = "Spill/TELL_CATH";
                UpdateAwareGuideContent(_awareGuideContent);
            }


        }
        else // This is triggered (seemingly...) ONLY when a room change occurs.
        {
            // Not sure about this one, ask Abbey / other developer to take a look.
            if(EventName == "LeaveSame" && !EventStatus){
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
            if (Room == CIRCLESROOM)
            {
                UpdateAwareGuideContent(_circlesRoomState);
            }
            if (Room == EMPTYROOM)
            {
                UpdateAwareGuideContent(_emptyRoomState);
            }
            if (Room == WINDOWEMPTYROOM)
            {
                UpdateAwareGuideContent(_windowEmptyRoomState);
            }

        }   
    }
}
