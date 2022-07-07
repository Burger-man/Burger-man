--This handles all the open and close functions for the GUI and it also handles the FPS counter. (Made by burger :D)
--(PS. DONT TOUCH PLS)

--Open GUI at start
script.Parent.Enabled = true

--Open pause GUI with button (Also close)
local UIS = game:GetService("UserInputService")
local toggle = false
script.Parent.menubtt.build.MouseButton1Click:Connect(function()
	if toggle then
		script.Parent.Credits.Visible = false
		script.Parent.Settings.Visible = false
		script.Parent.Background.Visible = false
		script.Parent.Frame.Visible = false	
		script.Parent.Pause.Visible = false
		script.Parent.menubtt.Visible = true
		script.Parent.Cash.Visible = true
		toggle = false
	elseif not toggle then
		script.Parent.Background.Visible = false
		script.Parent.Frame.Visible = false
		script.Parent.Pause.Visible = true
		script.Parent.menubtt.Visible = false
		script.Parent.Cash.Visible = false
		toggle = true
	end
end)

--Open and close credits frame
local clicked = false
script.Parent.Pause.Credits.MouseButton1Click:Connect(function()

	if not clicked then --Check if it was clicked
		clicked = true --Set it to true
		script.Parent.Credits.Visible = true
		script.Parent.Pause.Visible = false
		script.Parent.Settings2.Visible = false
	else --If not clicked then
		clicked = false --Set it to false
		script.Parent.Credits.Visible = false
		script.Parent.Pause.Visible = true
	end
end)



--Close GUI with GUI button
script.Parent.Frame.Continue.MouseButton1Click:Connect(function()
	script.Parent.Frame.Visible = false
	script.Parent.Settings.Visible = false
	script.Parent.Background.Visible = false
end)

--Close Pause GUI with GUI button
script.Parent.Pause.Continue.MouseButton1Click:Connect(function()
	script.Parent.Pause.Visible = false
	script.Parent.Settings.Visible = false
	script.Parent.Background.Visible = false
	script.Parent.menubtt.Visible = true
	script.Parent.Cash.Visible = true
end)


--Open and close settings frame
local clicked = false
script.Parent.Pause.Settings.MouseButton1Click:Connect(function()

	if not clicked then --Check if it was clicked
		clicked = true --Set it to true
		script.Parent.Settings.Visible = true
		script.Parent.Frame.Visible = false
		script.Parent.Credits.Visible = false
		script.Parent.Pause.Visible = false
	else --If not clicked then
		clicked = false --Set it to false
		script.Parent.Settings.Visible = false
		script.Parent.Pause.Visible = true
	end
end)



--FPS Counter in the frame
local RS = game:GetService("RunService")
local frames = 0

RS.RenderStepped:Connect(function()
	frames = frames + 1
end)

while wait(1) do
	script.Parent.Frame.FPS.Text = frames .. " FPS"
	script.Parent.Pause.FPS.Text = frames .. " FPS"
	script.Parent.Settings.FPS.Text = frames .. " FPS"
	frames = 0
end
