using System;

namespace EconomyBot {

public ErrorSolver {
    public String errorLister(int ErrorNumber) {
        Switch(ErrorNumber) {
        case 0:
				return "Just Alright";
				break;
			case 1:
				return "File is read only";
				break;
			case 2:
				return "File Non-Existant";
				break;
			case 3:
				return "Unknown, Unable to read file";
				break;
			case 4:
				return "Unknown, Unable to right file";
				break;
			case 5:
				return "Array Out of Bounds E!"
			case 6:
				return "Unknown Error has occurred";
				break;
			default:
				return "Unknown Error has occurred";
				break;
        }
    
    }
}
}
