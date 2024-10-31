const output = document.getElementById("output");
const input = document.getElementById("input");
const submit = document.getElementById("submit");

// Game State
let currentRoom = "start";
let inventory = [];
const rooms = {
    start: {
        description: "You are in a small, dimly lit room. There’s a door to the north.",
        commands: {
            go: {
                north: "hall"
            },
            take: {
                key: "A rusty key lies on the ground. You pick it up."
            }
        },
        items: ["key"]
    },
    hall: {
        description: "You are in a grand hallway with doors to the east and west.",
        commands: {
            go: {
                east: "library",
                west: "kitchen"
            }
        }
    },
    library: {
        description: "The library is filled with ancient books. A magical aura fills the room.",
        commands: {
            go: {
                west: "hall"
            },
            examine: {
                books: "The books seem enchanted but firmly in place on the shelves."
            }
        }
    },
    kitchen: {
        description: "The kitchen smells of stale food. There's a locked door here.",
        commands: {
            go: {
                east: "hall"
            },
            use: {
                key: () => {
                    if (inventory.includes("key")) {
                        outputMessage("The door unlocks. You may go south.");
                        rooms.kitchen.commands.go.south = "cellar";
                    } else {
                        outputMessage("You need a key to unlock this door.");
                    }
                }
            }
        }
    },
    cellar: {
        description: "A dark, damp cellar. You see a faint light coming from the corner.",
        commands: {}
    }
};

// Utility functions
function outputMessage(message) {
    output.innerHTML += `<p>${message}</p>`;
    output.scrollTop = output.scrollHeight;
}

function processCommand(command) {
    const [action, target] = command.toLowerCase().split(" ");

    if (action === "inventory") {
        displayInventory();
        return;
    }

    const room = rooms[currentRoom];
    const actions = room.commands;

    // Handle 'take' command
    if (action === "take" && room.items && room.items.includes(target)) {
        inventory.push(target);
        room.items = room.items.filter(item => item !== target);
        outputMessage(`You take the ${target}.`);
        return;
    }

    // Handle 'drop' command
    if (action === "drop" && inventory.includes(target)) {
        inventory = inventory.filter(item => item !== target);
        room.items.push(target);
        outputMessage(`You drop the ${target}.`);
        return;
    }

    if (actions[action]) {
        if (typeof actions[action][target] === "string") {
            currentRoom = actions[action][target];
            outputMessage(rooms[currentRoom].description);
        } else if (typeof actions[action][target] === "function") {
            actions[action][target]();
        } else {
            outputMessage(`You can't ${action} ${target} here.`);
        }
    } else {
        outputMessage(`Unknown command: ${command}`);
    }
}

function displayInventory() {
    if (inventory.length > 0) {
        outputMessage(`Inventory: ${inventory.join(", ")}`);
    } else {
        outputMessage("Your inventory is empty.");
    }
}

// Initialize game
outputMessage(rooms[currentRoom].description);

submit.addEventListener("click", () => {
    const command = input.value.trim();
    if (command) processCommand(command);
    input.value = "";
});

input.addEventListener("keypress", (e) => {
    if (e.key === "Enter") submit.click();
});
