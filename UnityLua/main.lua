local Player = Entity.Get("Player")
Player:SetName("Lua Player")

local Camera = Entity.Get("Main Camera")

local function Movement()
	local Speed = Input.GetKey(KeyCode.LeftShift) and 10 or 5
	local Horizontal = Input.GetAxis("Horizontal")
	local Vertical = Input.GetAxis("Vertical")

	Player:Translate(Vector3(Horizontal, 0, Vertical) * Speed * Time.Delta())
end

Cursor.SetLockState(CursorLockMode.Locked)
local function MouseLook()
	local MouseX = Input.GetAxis("Mouse X");
	local MouseY = Input.GetAxis("Mouse Y");

	Camera:SetAng(Camera:GetAng() + Vector3(-MouseY, 0, 0))
	Player:SetAng(Player:GetAng() + Vector3(0, MouseX, 0))
end

function UE:Update()
	Movement()
	MouseLook()
end