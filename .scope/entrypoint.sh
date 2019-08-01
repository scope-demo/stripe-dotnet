echo Installing Golang
sudo add-apt-repository ppa:ubuntu-lxc/stable
sudo apt-get update
sudo apt-get -y upgrade
sudo apt-get install golang

echo Install Stripe Mock
go get -u github.com/stripe/stripe-mock
stripe-mock &

echo Installing the ScopeAgent.Runner
dotnet tool install -g ScopeAgent.Runner

echo Fix Path
export PATH="$PATH:/root/.dotnet/tools"

echo Clean Solution
dotnet clean

echo Build Solution
dotnet build

echo Run Tests
cd src/StripeTests
scope-run dotnet test --framework netcoreapp2.1
