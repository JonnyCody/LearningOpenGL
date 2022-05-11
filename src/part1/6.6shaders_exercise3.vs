#version 330 core
layout (location = 0) in vec3 aPos;

out vec3 ourColor;

uniform vec3 offset;

void main()
{
    gl_Position = vec4(aPos + offset, 1.0);
    ourColor = aPos;
}