#pragma strict
var speed : float = 3.0;
var rotateSpeed : float = 10.0;


function Update () {
// Detect mouse left clicks
    if (Input.GetMouseButtonDown(0)) {
        // Check if the GameObject is clicked by casting a
        // Ray from the main camera to the touched position.
        var ray : Ray = Camera.main.ScreenPointToRay 
                            (Input.mousePosition);
        var hit : RaycastHit;
        // Cast a ray of distance 100, and check if this
        // collider is hit.
        if (collider.Raycast (ray, hit, 100.0)) {
            // Log a debug message
            Debug.Log("Moving the target");
            // Move the target forward
            transform.Translate(Vector3.forward * speed);       
            // Rotate the target along the y-axis
            transform.Rotate(Vector3.up * rotateSpeed);
        } else {
            // Clear the debug message
            Debug.Log("");
        }
    }
}