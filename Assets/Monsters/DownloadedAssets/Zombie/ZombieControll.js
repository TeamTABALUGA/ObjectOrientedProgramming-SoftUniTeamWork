// Require a character controller to be attached to the same game object
@script RequireComponent(CharacterController)




public var speed : float = 2; 
private var controller : CharacterController;
//Boolean
private var atack : boolean ;
private var target : Transform;
private var myTransform : Transform;
var moveSpeed : float = 3;

//Using Awake to set up parameters before Initialize
public function Awake() : void {
	controller = GetComponent(CharacterController);
	myTransform = transform;
	animator = GetComponent(Animator);
	animator.SetBool("Atack", false);
}

public function Start() : void {
	target = GameObject.FindWithTag("Player").transform;	
}

public function Update() : void {
	
	animator = GetComponent(Animator);	
   
}
function OnTriggerEnter(otherObj: Collider) : void {     
	animator = GetComponent(Animator);
	if (otherObj.tag == "Player"){
		moveSpeed = 0;
		animator.SetBool("Atack", true);
	}  		
}

function OnTriggerExit (other : Collider) {
	animator = GetComponent(Animator);
	if (other.tag == "Player"){
		moveSpeed = 3;
		animator.SetBool("Atack", false);
		canjump = true;
	}
}
