echo Installing Golang
add-apt-repository ppa:ubuntu-lxc/stable
apt-get update
apt-get -y upgrade
apt-get install golang -y

echo Reload bashrc
source ~/.bashrc

echo Install Stripe Mock
go get -u github.com/stripe/stripe-mock
stripe-mock &

echo Installing the ScopeAgent.Runner
dotnet tool install -g ScopeAgent.Runner

echo Fix Path
export PATH="$PATH:/root/.dotnet/tools"
cd src/StripeTests

echo Clean Solution
dotnet clean

echo Build Solution
dotnet build

echo Run Tests
scope-run dotnet test --framework netcoreapp2.1
