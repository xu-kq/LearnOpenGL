#version 330 core
out vec4 fragColor;

in vec3 ourColor;
in vec2 TexCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float mixValue;
void main() {
	fragColor = mix(texture(texture1, TexCoord * 2), texture(texture2, TexCoord * 2), mixValue);
}