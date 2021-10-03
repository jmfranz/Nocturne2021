using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareGuideStandville : ContextAwareGuide
{
    private string _securityroomState;
    private string _lastRoomState;
    private string _dogsRoomState;
    private string _washroomState;
    private string _mainroomState;
    private string _astronomyRoomState;

    const string WASHROOM = "WASHROOM";
    const string MAINROOM = "MAINROOM";
    const string ASTRONOMYROOM = "ASTRONOMYROOM";
    const string SECURITYROOM = "SECURITYROOM";
    const string DOGROOM = "DOGROOM";
    const string LASTROOM = "LASTROOM";

    public override void UpdateGuideState(bool eventChange)
    {
        if (eventChange)
        {
            if (EventName == "Game Start" && EventStatus) // Game not started
            {
                _washroomState = "WASHROOM_0";
                _astronomyRoomState = "WRONG_ROOM_1";
                _dogsRoomState = "WRONG_ROOM_1";
                _lastRoomState = "WRONG_ROOM_1";
                _securityroomState = "WRONG_ROOM_1";
                _mainroomState = "MAIN_ROOM_1";

                if (Room == WASHROOM)
                {
                    UpdateAwareGuideContent(_washroomState);
                }
                else if (Room == MAINROOM)
                {
                    UpdateAwareGuideContent(_mainroomState);
                }
                else
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
            }
            else if (EventName == "Game Start" && !EventStatus) // Story has started
            {
                _washroomState = "WASHROOM_1";
                _astronomyRoomState = "ASTRONOMY_ROOM_1";
                _dogsRoomState = "DOGS_ROOM_1";
                _lastRoomState = "LAST_ROOM_1";
                _securityroomState = "SECURITY_ROOM_1";
                _mainroomState = "MAIN_ROOM_2";

                if (Room == WASHROOM)
                {
                    UpdateAwareGuideContent(_washroomState);
                }
                else if (Room == MAINROOM)
                {
                    UpdateAwareGuideContent(_mainroomState);
                }
                else if (Room == ASTRONOMYROOM)
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
                else if (Room == DOGROOM)
                {
                    UpdateAwareGuideContent(_dogsRoomState);
                }
                else if (Room == LASTROOM)
                {
                    UpdateAwareGuideContent(_lastRoomState);
                }
                else if (Room == SECURITYROOM)
                {
                    UpdateAwareGuideContent(_securityroomState);
                }
            }
            else if (EventName == "Entered Security Room" && !EventStatus) // Active user Entered Security Room
            {
                _securityroomState = "SECURITYROOM_2";

                if (Room == SECURITYROOM)
                {
                    UpdateAwareGuideContent(_securityroomState);
                }
            }
            else if (EventName == "Start Chase" && EventStatus) // Chase has started
            {
                _dogsRoomState = "ALL_OTHER_SPACES_1";
                _washroomState = "ALL_OTHER_SPACES_1";
                _mainroomState = "ALL_OTHER_SPACES_1";
                _astronomyRoomState = "ALL_OTHER_SPACES_1";
                _securityroomState = "SECURITY_ROOM_3";

                if (Room == SECURITYROOM)
                {
                    UpdateAwareGuideContent(_securityroomState);
                }
                else if (Room != LASTROOM)
                {
                    UpdateAwareGuideContent(_lastRoomState);
                }
            }
            else if (EventName == "Escaped Shadow" && !EventStatus) // Active user escaped shadow
            {
                _securityroomState = "SECURITYROOM_4";
                _washroomState = "WASHROOM_1";
                _mainroomState = "MAIN_ROOM_2";
                _astronomyRoomState = "ASTRONOMY_ROOM_1";

                if (Room == WASHROOM)
                {
                    UpdateAwareGuideContent(_washroomState);
                }
                else if (Room == MAINROOM)
                {
                    UpdateAwareGuideContent(_mainroomState);

                }
                else if (Room == SECURITYROOM)
                {
                    UpdateAwareGuideContent(_securityroomState);
                }
                else if (Room == ASTRONOMYROOM)
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
            }
            else if (EventName == "Player entered dog room" && !EventStatus) // Active user entered dog room
            {
                _dogsRoomState = "DOGS_ROOM_3";

                if (Room == "DOGSROOM")
                {
                    UpdateAwareGuideContent(_dogsRoomState);
                }
            }
            else if (EventName == "Yes trust dog" && !EventStatus) // Yes trust dog
            {
                _lastRoomState = "LAST_ROOM_2";
                if (Room == LASTROOM)
                {
                    UpdateAwareGuideContent(_lastRoomState);
                }
            }
            else if (EventName == "Ending John enters Main Room" && !EventStatus) // Entered main room for "Yes, trust dog" ending
            {
                _mainroomState = "MAIN_ROOM_3";

                if (Room == MAINROOM)
                {
                    UpdateAwareGuideContent(_mainroomState);
                }
            }
            else if (EventName == "Ending John enters Main Room No" && !EventStatus) // Entered main room for "No, don't trust dog" ending
            {
                _mainroomState = "MAIN_ROOM_4";

                if (Room == MAINROOM)
                {
                    UpdateAwareGuideContent(_mainroomState);
                }
            }
            else if (EventName == "Entered Astronomy Room" && !EventStatus) // Active user entered astronomy room
            {
                _astronomyRoomState = "ASTRONOMY_ROOM_2";

                if (Room == ASTRONOMYROOM)
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
            }
            else if (EventName == "Finished Reading Mural" && !EventStatus) // Mural has been read
            {
                _astronomyRoomState = "ASTRONOMY_ROOM_3";

                if (Room == ASTRONOMYROOM)
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
            }
            else if (EventName == "Shadow Disappears" && !EventStatus) // Shadow disappears for "No, don't trust dog" ending
            {
                _astronomyRoomState = "ASTRONOMY_ROOM_4";

                if (Room == ASTRONOMYROOM)
                {
                    UpdateAwareGuideContent(_astronomyRoomState);
                }
            }
        }
        else
        {
            // Update room to last updated room state
            if (Room == SECURITYROOM)
            {
                UpdateAwareGuideContent(_securityroomState);
            }
            else if (Room == LASTROOM)
            {
                UpdateAwareGuideContent(_lastRoomState);

            }
            else if (Room == MAINROOM)
            {
                UpdateAwareGuideContent(_mainroomState);
            }
            else if (Room == WASHROOM)
            {
                UpdateAwareGuideContent(_washroomState);
            }
            else if (Room == ASTRONOMYROOM)
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
            else if (Room == "DOGSROOM")
            {
                UpdateAwareGuideContent(_dogsRoomState);
            }
        }   
    }
}
