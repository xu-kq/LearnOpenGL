#version 330 core
out vec4 fragColor;

struct Light {
	vec3 position;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

uniform Light light;
void main() {
	fragColor = vec4(light.diffuse, 1.0f);
}