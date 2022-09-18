cmake_minimum_required(VERSION 3.10.0)

find_path(vcpkg_path vcpkg.exe)
set(CMAKE_TOOLCHAIN_FILE ${vcpkg_path}/scripts/buildsystems/vcpkg.cmake)

set(CMAKE_CXX_STANDARD 11)
project(ModelLoading)

include_directories (
	${PROJECT_SOURCE_DIR}/include
)

add_executable(ModelLoading main.cpp stbi_image.cpp)

# glad
find_package(glad CONFIG REQUIRED)
target_link_libraries(ModelLoading PRIVATE glad::glad)


# glfw3
find_package(glfw3 CONFIG REQUIRED)
target_link_libraries(ModelLoading PRIVATE  glfw)

# glm
find_package(glm CONFIG REQUIRED)
target_link_libraries(ModelLoading PRIVATE glm::glm)

# assimp
find_package(assimp CONFIG REQUIRED)
target_link_libraries(ModelLoading PRIVATE assimp::assimp)